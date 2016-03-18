Imports System.Data

Class MainWindow
    Private DBConString As String

    Private ActiveMonster() As Monster
    Private RewardEXP As Integer = 0
    Private RewardGil As Integer = 0
    Private RewardItems() As DroppedItem
    Private appBaseDir As String = System.AppDomain.CurrentDomain.BaseDirectory

    Public Sub New()
        DBConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & AppDomain.CurrentDomain.BaseDirectory & "\FinalFantasyRPG.mdb"
        InitializeComponent()

        BuildAndSetCursor()
        BuildItemTable()
        AddMagicToDatagrid()
        AddItemsToDatagrid()
    End Sub

    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        AddStatusToCombobox()
    End Sub

    Private Sub BuildAndSetCursor()
        Me.Cursor = New Cursor(appBaseDir & "Cursor.cur")
    End Sub

    Private Sub AddStatusToCombobox()
        Dim Str As String() = System.IO.File.ReadAllLines(appBaseDir & "\StatusNames.txt")
        For i = 0 To 104
            cbAddStatus.Items.Add(Str(i))
        Next
    End Sub


    Private BlackMagicDataSet As New DataSet()
    Private WhiteMagicDataSet As New DataSet()
    Private TimeMagicDataSet As New DataSet()
    Private ItemDataSet As New DataSet()
    Private WeaponDataSet As New DataSet()
    Private ArmorDataSet As New DataSet()

    Private Sub AddMagicToDatagrid()
        Dim DBCon As New System.Data.OleDb.OleDbConnection(DBConString)
        Dim DBAdap As System.Data.OleDb.OleDbDataAdapter

        DBAdap = New System.Data.OleDb.OleDbDataAdapter("SELECT mLevel As L, mName As Name, mTarget As Target, mCost As MPCost, mCOS As COS, mEffect As Effect From MagicBlack;", DBCon)
        DBAdap.Fill(BlackMagicDataSet, "Black Magic")
        DBAdap = New System.Data.OleDb.OleDbDataAdapter("SELECT mLevel As L, mName As Name, mTarget As Target, mCost As MPCost, mCOS As COS, mEffect As Effect From MagicWhite;", DBCon)
        DBAdap.Fill(WhiteMagicDataSet, "White Magic")
        DBAdap = New System.Data.OleDb.OleDbDataAdapter("SELECT mLevel As L, mName As Name, mTarget As Target, mCost As MPCost, mCOS As COS, mEffect As Effect From MagicTime;", DBCon)
        DBAdap.Fill(TimeMagicDataSet, "Time Magic")
        DBCon.Close()

        dgvCreateEnemyBlackMagic.ItemsSource = BlackMagicDataSet.Tables("Black Magic").DefaultView
        dgvCreateEnemyWhiteMagic.ItemsSource = WhiteMagicDataSet.Tables("White Magic").DefaultView
        dgvCreateEnemyTimeMagic.ItemsSource = TimeMagicDataSet.Tables("Time Magic").DefaultView
    End Sub

    Private Sub AddItemsToDatagrid()
        Dim DBCon As New System.Data.OleDb.OleDbConnection(DBConString)
        Dim DBAdap As System.Data.OleDb.OleDbDataAdapter

        DBAdap = New System.Data.OleDb.OleDbDataAdapter("SELECT iName As Name, iCost As Cost, iAvailability As Availability, iTarget As Target, iEffect As Effect From ItemInventory ORDER BY iAvailability DESC;", DBCon)
        DBAdap.Fill(ItemDataSet, "Item")
        DBAdap = New System.Data.OleDb.OleDbDataAdapter("SELECT iName As Name, iCost As Cost, iAvailability As Availability, iTarget As Target, iEffect As Effect From ItemRecovery ORDER BY iAvailability DESC;", DBCon)
        DBAdap.Fill(ItemDataSet, "Recovery")
        DBAdap = New System.Data.OleDb.OleDbDataAdapter("SELECT wName As Name, wType As Type, wSlot As Slot, wCost As Cost, wAvailability As Availability, wDamage As Damage, wAbility As Ability From ItemWeapon ORDER BY wAvailability DESC;", DBCon)
        DBAdap.Fill(ItemDataSet, "Weapon")
        DBAdap = New System.Data.OleDb.OleDbDataAdapter("SELECT aName As Name, aType As Type, aCost As Cost, aAvailability As Availability, aARM As ARM, aMARM As MARM, aEVA as EVA, aMEVA as MEVA, aAbility As Ability From ItemArmor ORDER BY aAvailability DESC;", DBCon)
        DBAdap.Fill(ItemDataSet, "Armor")


        dgvItems.ItemsSource = ItemDataSet.Tables("Item").DefaultView
        dgvRecovery.ItemsSource = ItemDataSet.Tables("Recovery").DefaultView
        dgvWeapon.ItemsSource = ItemDataSet.Tables("Weapon").DefaultView
        dgvArmor.ItemsSource = ItemDataSet.Tables("Armor").DefaultView
    End Sub

    Private TreasureTableItems() As DroppedItem
    Private Sub BuildItemTable()
        Dim DBCon As New System.Data.OleDb.OleDbConnection(DBConString)
        Dim DBCmd As New System.Data.OleDb.OleDbCommand()
        Dim dbDR As System.Data.OleDb.OleDbDataReader

        DBCon.Open()
        DBCmd.Connection = DBCon
        DBCmd.CommandText = "SELECT * FROM ItemRecovery"
        dbDR = DBCmd.ExecuteReader()
        While dbDR.Read()
            If TreasureTableItems Is Nothing Then
                ReDim TreasureTableItems(0)
                TreasureTableItems(0) = New DroppedItem(dbDR(0), dbDR(1), dbDR(2), dbDR(4))
            Else
                ReDim Preserve TreasureTableItems(UBound(TreasureTableItems) + 1)
                TreasureTableItems(UBound(TreasureTableItems)) = New DroppedItem(dbDR(0), dbDR(1), dbDR(2), dbDR(4))
            End If
        End While
        dbDR.Close()

        DBCmd.CommandText = "SELECT * FROM ItemInventory"
        dbDR = DBCmd.ExecuteReader()
        While dbDR.Read()
            ReDim Preserve TreasureTableItems(UBound(TreasureTableItems) + 1)
            TreasureTableItems(UBound(TreasureTableItems)) = New DroppedItem(dbDR(0), dbDR(1), dbDR(2), dbDR(4))
        End While
        dbDR.Close()
        DBCon.Close()
    End Sub

    Protected Friend Sub AddMonster(ByVal m As Monster)
        If ActiveMonster IsNot Nothing Then
            ReDim Preserve ActiveMonster(UBound(ActiveMonster) + 1)
            ActiveMonster(UBound(ActiveMonster)) = m
        Else
            ReDim Preserve ActiveMonster(0)
            ActiveMonster(0) = m
        End If
        RefreshEnemyList()
    End Sub

    Friend Sub DefeatMonster(ByVal i As Integer) 'Party recieves rewards for defeating the monster
        RefreshEnemyList()
    End Sub

    Private Sub RefreshEnemyList()
        If ActiveMonster IsNot Nothing Then
            lbActiveEnemy.Items.Clear()
            For i = 0 To UBound(ActiveMonster)
                If ActiveMonster IsNot Nothing Then
                    lbActiveEnemy.Items.Add(ActiveMonster(i).GetName)
                End If
            Next
        End If
    End Sub

    Private Sub lbActiveEnemy_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbActiveEnemy.SelectionChanged
        If lbActiveEnemy.SelectedIndex > -1 Then
            If ActiveMonster.Length > lbActiveEnemy.SelectedIndex Then
                If ActiveMonster(lbActiveEnemy.SelectedIndex) IsNot Nothing Then
                    UpdateDisplayMonster()
                End If
            End If
        End If
    End Sub

    'BUTTON WITHIN dgvMagicAttack
    Private CurrentDisplayMagic() As Magic
    Private CurrentDisplayTreasure() As DroppedItem
    Private Sub SubtractSelectedMPAmount(sender As Object, e As RoutedEventArgs)
        ActiveMonster(lbActiveEnemy.SelectedIndex).SubtractMP(dgvAttackMagic.SelectedItem.MPCost)
        UpdateDisplayMonster()
    End Sub

    Private Sub UpdateDisplayMonster()
        If ActiveMonster IsNot Nothing And ActiveMonster.Length > 0 Then
            With ActiveMonster(lbActiveEnemy.SelectedIndex)
                CurrentDisplayMagic = .GetMagic()
                CurrentDisplayTreasure = .GetTreasure()

                'HP/MP
                tbSelectedEnemyHPCurrent.Text = .GetCurrentHP
                tbSelectedEnemyMPCurrent.Text = .GetCurrentMP

                'Status Effects
                Dim Str() As String
                Str = .GetStatusStr()
                lbEnemyStatus.Items.Clear()
                If Str IsNot Nothing Then
                    For i = 0 To UBound(Str)
                        lbEnemyStatus.Items.Add(Str(i))
                    Next
                End If

                'Attributes
                tbCurrentSTR.Text = .GetSTR()
                tbCurrentVIT.Text = .GetVIT()
                tbCurrentSPD.Text = .GetSPD()
                tbCurrentAGI.Text = .GetAGI()
                tbCurrentMAG.Text = .GetMAG()
                tbCurrentSPR.Text = .GetSPR()
                '

                'Combat Stats
                tbCurrentEVA.Text = .GetEvasion()
                tbCurrentMEVA.Text = .GetMagicEvasion()
                tbCurrentARM.Text = .GetArmor()
                tbCurrentMARM.Text = .GetMagicArmor()
                tbCurrentACC.Text = .GetAccuracy()
                tbCurrentMACC.Text = .GetMagicAccuracy()
                tbCurrentDEX.Text = .GetDexterity()
                tbCurrentMIND.Text = .GetMind()
                '

                'Attack and Damage
                tbAttackCOS.Text = "D% Roll Under " & .GetAccuracy() & " - Target's Evasion"
                Dim mAttribute As Integer = 0
                If .GetDamageText().IndexOf("STR") <> -1 Then mAttribute = .GetSTR() Else mAttribute = .GetAGI()
                tbAttackDamage.Text = CInt(Mid(.GetDamageText(), 1, .GetDamageText().IndexOf("x") - 1)) * mAttribute & " + " & Mid(.GetDamageText(), .GetDamageText().LastIndexOf(" ") + 2) &
                    " [" & .GetDamageText() & "]"

                'remove items in collection
                dgvAttackMagic.Items.Clear()
                Dim tMag() As Magic = .GetMagic()
                If tMag IsNot Nothing Then
                    For i = 0 To UBound(tMag)
                        dgvAttackMagic.Items.Add(tMag(i))
                    Next
                End If
                dgvAttackMagic.Items.Refresh()

                'remove items in collection
                dgvRewardTable.Items.Clear()
                Dim tRwd() As DroppedItem = .GetTreasure()
                If tRwd IsNot Nothing Then
                    For i = 0 To UBound(tRwd)
                        dgvRewardTable.Items.Add(tRwd(i))
                    Next
                End If
                dgvRewardTable.Items.Refresh()
            End With
        Else
            'CurrentDisplayMagic = Nothing 'NEW
            'CurrentDisplayTreasure = Nothing
            tbSelectedEnemyHPCurrent.Text = ""
            tbSelectedEnemyMPCurrent.Text = ""
            lbEnemyStatus.Items.Clear()

            'Attributes
            tbCurrentSTR.Text = ""
            tbCurrentVIT.Text = ""
            tbCurrentSPD.Text = ""
            tbCurrentAGI.Text = ""
            tbCurrentMAG.Text = ""
            tbCurrentSPR.Text = ""

            'Combat Stats
            tbCurrentEVA.Text = ""
            tbCurrentMEVA.Text = ""
            tbCurrentARM.Text = ""
            tbCurrentMARM.Text = ""
            tbCurrentACC.Text = ""
            tbCurrentMACC.Text = ""
            tbCurrentDEX.Text = ""
            tbCurrentMIND.Text = ""
            '

            'Attack and Damage
            tbAttackCOS.Text = ""
            Dim mAttribute As Integer = 0
            tbAttackDamage.Text = ""

            dgvRewardTable.Items.Clear()
            dgvRewardTable.Items.Refresh()
            dgvAttackMagic.Items.Clear()
            dgvAttackMagic.Items.Refresh()
        End If
    End Sub

    Private Sub UpdateLootTable()
        If RewardItems IsNot Nothing Then
            lbRewardItems.Items.Clear()
            For i = 0 To UBound(RewardItems)
                lbRewardItems.Items.Add(RewardItems(i).Name)
            Next
        End If
    End Sub

    Private Sub ClearLootTable()
        RewardItems = Nothing
        lbRewardItems.Items.Clear()
    End Sub

    Private Sub btnRoundEnd_Click(sender As Object, e As RoutedEventArgs) Handles btnRoundEnd.Click
        If ActiveMonster IsNot Nothing Then
            For i = 0 To UBound(ActiveMonster)
                ActiveMonster(i).StatusCleanup()
            Next
            UpdateDisplayMonster()
        End If
    End Sub

    Private Sub btnAddStatus_Click(sender As Object, e As RoutedEventArgs) Handles btnAddStatus.Click
        If lbActiveEnemy.SelectedIndex > -1 Then
            ActiveMonster(lbActiveEnemy.SelectedIndex).AddStatus(cbAddStatus.Text, tbStatusDuration.Text)
            UpdateDisplayMonster()
        End If
    End Sub

    Private Sub btnRemoveStatus_Click(sender As Object, e As RoutedEventArgs) Handles btnRemoveStatus.Click
        If lbActiveEnemy.SelectedIndex > -1 Then
            If lbEnemyStatus.SelectedIndex > -1 Then
                ActiveMonster(lbActiveEnemy.SelectedIndex).RemoveStatus(lbEnemyStatus.SelectedItem)
                UpdateDisplayMonster()
            End If
        End If
    End Sub

    Private Sub btnExecuteHP_Click(sender As Object, e As RoutedEventArgs) Handles btnExecuteHP.Click
        If ActiveMonster IsNot Nothing Then
            If ActiveMonster.Length > 0 Then
                With ActiveMonster(lbActiveEnemy.SelectedIndex)
                    If tbDamageARM.Text <> "" Then
                        If IsNumeric(tbDamageARM.Text) Then
                            If CInt(tbDamageARM.Text) - .GetArmor > 0 Then
                                .SubtractHP(CInt(tbDamageARM.Text) - .GetArmor)
                            End If
                            tbDamageARM.Text = ""
                        End If
                    End If
                    If tbDamageMARM.Text <> "" Then
                        If IsNumeric(tbDamageMARM.Text) Then
                            If CInt(tbDamageMARM.Text) - .GetMagicArmor > 0 Then
                                .SubtractHP(CInt(tbDamageMARM.Text) - .GetMagicArmor)
                            End If
                            tbDamageMARM.Text = ""
                        End If
                    End If
                    If tbDamageNONE.Text <> "" Then
                        If IsNumeric(tbDamageNONE.Text) Then
                            .SubtractHP(CInt(tbDamageNONE.Text))
                            tbDamageNONE.Text = ""
                        End If
                    End If
                    If tbHealing.Text <> "" Then
                        If IsNumeric(tbHealing.Text) Then
                            .AddHP(CInt(tbHealing.Text))
                            tbHealing.Text = ""
                        End If
                    End If

                    If .GetCurrentHP > 0 Then
                        UpdateDisplayMonster()
                    Else
                        KillMonster(lbActiveEnemy.SelectedIndex)
                        RemoveMonster(lbActiveEnemy.SelectedIndex)
                    End If
                End With
            End If
        End If
    End Sub

    Private Sub btnExecuteMP_Click(sender As Object, e As RoutedEventArgs) Handles btnExecuteMP.Click
        If ActiveMonster IsNot Nothing Then
            If ActiveMonster.Length > 0 Then
                With ActiveMonster(lbActiveEnemy.SelectedIndex)
                    If tbSubtractMP.Text <> "" Then
                        If IsNumeric(tbSubtractMP.Text) Then
                            .SubtractMP(CInt(tbSubtractMP.Text))
                            tbSubtractMP.Text = ""
                        End If
                    End If
                    If tbAddMP.Text <> "" Then
                        If IsNumeric(tbAddMP.Text) Then
                            .AddMP(CInt(tbAddMP.Text))
                            tbAddMP.Text = ""
                        End If
                    End If
                End With
                UpdateDisplayMonster()
            End If
        End If
    End Sub

    Private Sub btnKillMonster_Click(sender As Object, e As RoutedEventArgs) Handles btnKillMonster.Click
        KillMonster(lbActiveEnemy.SelectedIndex)
        RemoveMonster(lbActiveEnemy.SelectedIndex)
    End Sub

    Private Sub KillMonster(ByVal i As Integer)
        Dim n As Integer = rn.Next(1, 100)
        If ActiveMonster IsNot Nothing Then
            If ActiveMonster.Length > 0 Then
                If i > -1 Then
                    RewardEXP += ActiveMonster(i).GetXPModifier
                    RewardGil += ActiveMonster(i).GetGilModifier
                    tbBaseEXP.Text = RewardEXP
                    tbBaseGil.Text = RewardGil

                    If RewardItems IsNot Nothing Then
                        ReDim Preserve RewardItems(UBound(RewardItems) + 1)
                    Else
                        ReDim RewardItems(0)
                    End If

                    If n >= 51 Then
                        If ActiveMonster(i).GetTreasure(0).Name <> "" Then RewardItems(UBound(RewardItems)) = ActiveMonster(i).GetTreasure(0)
                    ElseIf n >= 25 And n <= 50 Then
                        If ActiveMonster(i).GetTreasure(1).Name <> "" Then RewardItems(UBound(RewardItems)) = ActiveMonster(i).GetTreasure(1)
                    ElseIf n >= 8 And n <= 24 Then
                        If ActiveMonster(i).GetTreasure(2).Name <> "" Then RewardItems(UBound(RewardItems)) = ActiveMonster(i).GetTreasure(2)
                    ElseIf n >= 1 And n <= 7 Then
                        If ActiveMonster(i).GetTreasure(3).Name <> "" Then RewardItems(UBound(RewardItems)) = ActiveMonster(i).GetTreasure(3)
                    End If
                End If
            End If
        End If
        UpdateLootTable()
    End Sub

    Private Sub btnRemoveMonster_Click(sender As Object, e As RoutedEventArgs) Handles btnRemoveMonster.Click
        RemoveMonster(lbActiveEnemy.SelectedIndex)
    End Sub

    Private Sub RemoveMonster(ByVal i As Integer)
        If ActiveMonster IsNot Nothing Then
            If ActiveMonster.Length > 0 Then
                If i > -1 Then
                    ActiveMonster(lbActiveEnemy.SelectedIndex) = Nothing
                    For j = i To UBound(ActiveMonster) - 1
                        ActiveMonster(j) = ActiveMonster(j + 1)
                    Next
                    ReDim Preserve ActiveMonster(UBound(ActiveMonster) - 1)

                    lbActiveEnemy.Items.Remove(lbActiveEnemy.SelectedIndex)
                    RefreshEnemyList()

                    If lbActiveEnemy.Items.Count > 0 Then
                        lbActiveEnemy.SelectedIndex = 0
                    Else
                        UpdateDisplayMonster()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btnSplitReward_Click(sender As Object, e As RoutedEventArgs) Handles btnSplitReward.Click
        If tbPartySize.Text <> "" Then
            If IsNumeric(tbPartySize.Text) Then
                tbSplitGil.Text = CInt((RewardGil / CInt(tbPartySize.Text)) + 0.5)
                tbSplitExp.Text = CInt((RewardEXP / CInt(tbPartySize.Text)) + 0.5)
            End If
        Else
            tbSplitGil.Text = RewardGil
            tbSplitExp.Text = RewardEXP
        End If
    End Sub

    Private Sub btnClearReward_Click(sender As Object, e As RoutedEventArgs) Handles btnClearReward.Click
        RewardEXP = 0
        RewardGil = 0
        tbBaseEXP.Text = ""
        tbBaseGil.Text = ""
        tbSplitGil.Text = ""
        tbSplitExp.Text = ""
        ClearLootTable()
    End Sub

    Private ItemShopDataSet As New DataSet()

    Private Sub btnGenerateShop_Click(sender As Object, e As RoutedEventArgs) Handles btnGenerateShop.Click
        Dim Availability As Integer = 100
        If tbAvailability.Text <> "" Then
            If IsNumeric(tbAvailability.Text) Then
                Availability = CInt(tbAvailability.Text)

                ItemShopDataSet.Clear()

                Dim DBCon As New System.Data.OleDb.OleDbConnection(DBConString)
                Dim DBAdap As System.Data.OleDb.OleDbDataAdapter

                DBAdap = New System.Data.OleDb.OleDbDataAdapter("SELECT * FROM ItemInventory WHERE iAvailability>=" + CStr(Availability) + " ORDER BY iAvailability ASC;", DBCon)
                DBAdap.Fill(ItemShopDataSet, "Item")
                DBAdap = New System.Data.OleDb.OleDbDataAdapter("SELECT * FROM ItemRecovery WHERE iAvailability>=" + CStr(Availability) + " ORDER BY iAvailability ASC;", DBCon)
                DBAdap.Fill(ItemShopDataSet, "Recovery")
                DBAdap = New System.Data.OleDb.OleDbDataAdapter("SELECT * FROM ItemWeapon WHERE wAvailability>=" + CStr(Availability) + " ORDER BY wAvailability ASC;", DBCon)
                DBAdap.Fill(ItemShopDataSet, "Weapon")
                DBAdap = New System.Data.OleDb.OleDbDataAdapter("SELECT * FROM ItemArmor WHERE aAvailability>=" + CStr(Availability) + " ORDER BY aAvailability ASC;", DBCon)
                DBAdap.Fill(ItemShopDataSet, "Armor")

                dgvItemShop.ItemsSource = ItemShopDataSet.Tables("Item").DefaultView
                dgvRecoveryShop.ItemsSource = ItemShopDataSet.Tables("Recovery").DefaultView
                dgvWeaponShop.ItemsSource = ItemShopDataSet.Tables("Weapon").DefaultView
                dgvArmorShop.ItemsSource = ItemShopDataSet.Tables("Armor").DefaultView
            End If
        End If
    End Sub

#Region "CREATE ENEMY"
    Private mLVL, mHP, mMP, mSTR, mVIT, mSPD, mAGI, mMAG, mSPR As Integer
    Private mACC, mMACC, mDEX, mMND, mARM, mMARM, mEVA, mMEVA As Integer
    Private DamageText As String
    Private mCreateEnemyMagic() As Magic

    Private Sub btnClearSettings_Click(sender As Object, e As RoutedEventArgs) Handles btnClearSettings.Click
        mLVL = 0
        mHP = 0
        mMP = 0
        mSTR = 0
        mVIT = 0
        mSPD = 0
        mAGI = 0
        mMAG = 0
        mSPR = 0
        mACC = 0
        mMACC = 0
        mDEX = 0
        mMND = 0
        mARM = 0
        mMARM = 0
        mEVA = 0
        mMEVA = 0
        DamageText = ""

        rbTypeRegular.IsChecked = True
        rbHitBase10.IsChecked = True
        rbMagBase00.IsChecked = True
        rbArmBase05.IsChecked = True
        rbMArmBase05.IsChecked = True
        rbDamDie6.IsChecked = True

        cbCreateMonsterStrength.IsChecked = False
        cbCreateMonsterSpeed.IsChecked = False
        cbCreateMonsterMagic.IsChecked = False

        tbCreateMonsterACC.Text = ""
        tbCreateMonsterAGI.Text = ""
        tbCreateMonsterARM.Text = ""
        tbCreateMonsterDEX.Text = ""
        tbCreateMonsterEVA.Text = ""
        tbCreateMonsterHP.Text = ""
        tbCreateMonsterLevel.Text = ""
        tbCreateMonsterMACC.Text = ""
        tbCreateMonsterMAG.Text = ""
        tbCreateMonsterMARM.Text = ""
        tbCreateMonsterMEVA.Text = ""
        tbCreateMonsterMIND.Text = ""
        tbCreateMonsterMP.Text = ""
        tbCreateMonsterSPD.Text = ""
        tbCreateMonsterSPR.Text = ""
        tbCreateMonsterSTR.Text = ""
        tbCreateMonsterVIT.Text = ""
        tbMonsterName.Text = ""
        tbMonsterQuantity.Text = ""

        'mCreateEnemyMagic = Nothing
        lbCreateEnemySpells.Items.Clear()
    End Sub
    Private Sub btnCreateMonsterRandomize_Click(sender As Object, e As RoutedEventArgs) Handles btnCreateMonsterRandomize.Click
        If IsNumeric(tbCreateMonsterLevel.Text) Then
            mLVL = Val(tbCreateMonsterLevel.Text)
            If mLVL < 0 Or mLVL > 99 Then
                mLVL = 0
                Exit Sub
            End If
            SetAttributes()
        End If
    End Sub
    Private Sub SetAttributes()
        Dim t As Integer
        Dim Str As Integer = 10
        Dim Vit As Integer = 10
        Dim Spd As Integer = 10
        Dim Agi As Integer = 10
        Dim Mag As Integer = 10
        Dim Spr As Integer = 10

        Dim upperLimit As Integer = 0

        'set up prioritization
        If cbCreateMonsterStrength.IsChecked Then
            Str = 20
            Vit = 20
        End If
        If cbCreateMonsterSpeed.IsChecked Then
            Spd = 20
            Agi = 20
        End If
        If cbCreateMonsterMagic.IsChecked Then
            Mag = 20
            Spr = 20
        End If

        upperLimit = Str + Vit + Spd + Agi + Mag + Spr

        mSTR = 1
        mVIT = 1
        mSPD = 1
        mMAG = 1
        mAGI = 1
        mSPR = 1

        For i = 1 To mLVL + 29
            t = CInt(Math.Floor((upperLimit - 1 + 1) * Rnd())) + 1
            If t > 0 And t <= Str Then
                mSTR += 1
            ElseIf t > Str And t <= Str + Vit Then
                mVIT += 1
            ElseIf t > Str + Vit And t <= Str + Vit + Spd Then
                mSPD += 1
            ElseIf t > Str + Vit + Spd And t <= Str + Vit + Spd + Agi Then
                mAGI += 1
            ElseIf t > Str + Vit + Spd + Agi And t <= Str + Vit + Spd + Agi + Mag Then
                mMAG += 1
            ElseIf t > Str + Vit + Spd + Agi + Mag And t <= Str + Vit + Spd + Agi + Mag + Spr Then
                mSPR += 1
            End If
        Next
        tbCreateMonsterSTR.Text = mSTR
        tbCreateMonsterVIT.Text = mVIT
        tbCreateMonsterSPD.Text = mSPD
        tbCreateMonsterAGI.Text = mAGI
        tbCreateMonsterMAG.Text = mMAG
        tbCreateMonsterSPR.Text = mSPR
    End Sub
    Private Sub btnCreateMonsterCalculate_Click(sender As Object, e As RoutedEventArgs) Handles btnCreateMonsterCalculate.Click
        '//check level
        If IsNumeric(tbCreateMonsterLevel.Text) Then
            mLVL = Val(tbCreateMonsterLevel.Text)
            If mLVL < 0 Or mLVL > 99 Then
                mLVL = 0
                Exit Sub
            End If

            'Everything Checks Out
            If GetAttributes() Then
                GetHPMP()
                GetCombatStats()
                GetDamage()
            End If
        Else
            tbCreateMonsterLevel.Text = ""
        End If
    End Sub
    Private Function GetAttributes() As Boolean
        'Returns True if all attributes are present
        If tbCreateMonsterSTR.Text = "" Or Not IsNumeric(tbCreateMonsterSTR.Text) Then Return False
        If tbCreateMonsterVIT.Text = "" Or Not IsNumeric(tbCreateMonsterVIT.Text) Then Return False
        If tbCreateMonsterSPD.Text = "" Or Not IsNumeric(tbCreateMonsterSPD.Text) Then Return False
        If tbCreateMonsterAGI.Text = "" Or Not IsNumeric(tbCreateMonsterAGI.Text) Then Return False
        If tbCreateMonsterMAG.Text = "" Or Not IsNumeric(tbCreateMonsterMAG.Text) Then Return False
        If tbCreateMonsterSPR.Text = "" Or Not IsNumeric(tbCreateMonsterSPR.Text) Then Return False

        mSTR = CInt(tbCreateMonsterSTR.Text)
        mVIT = CInt(tbCreateMonsterVIT.Text)
        mSPD = CInt(tbCreateMonsterSPD.Text)
        mAGI = CInt(tbCreateMonsterAGI.Text)
        mMAG = CInt(tbCreateMonsterMAG.Text)
        mSPR = CInt(tbCreateMonsterSPR.Text)
        Return True
    End Function
    Private Sub GetHPMP()
        Dim locHitBase As Double
        Dim locMagBase As Double

        If rbHitBase10.IsChecked Then
            locHitBase = 1.0
        ElseIf rbHitBase15.IsChecked Then
            locHitBase = 1.5
        ElseIf rbHitBase20.IsChecked Then
            locHitBase = 2.0
        ElseIf rbHitBase40.IsChecked Then
            locHitBase = 4.0
        ElseIf rbHitBase60.IsChecked Then
            locHitBase = 6.0
        ElseIf rbHitBase80.IsChecked Then
            locHitBase = 8.0
        End If

        If rbMagBase00.IsChecked Then
            locMagBase = 0.0
        ElseIf rbMagBase05.IsChecked Then
            locMagBase = 0.5
        ElseIf rbMagBase10.IsChecked Then
            locMagBase = 1.0
        ElseIf rbMagBase15.IsChecked Then
            locMagBase = 1.5
        ElseIf rbMagBase20.IsChecked Then
            locMagBase = 2.0
        ElseIf rbMagBase40.IsChecked Then
            locMagBase = 4.0
        End If

        If rbTypeRegular.IsChecked Then
            mHP = (locHitBase * mVIT * mLVL)
            mMP = (locMagBase * mSPR * mLVL)
        ElseIf rbTypeNotorious.IsChecked Then
            mHP = (locHitBase * mVIT * mLVL) * 2
            mMP = (locMagBase * mSPR * mLVL) * 1.5
        ElseIf rbTypeBoss.IsChecked Then
            mHP = (locHitBase * mVIT * mLVL) * 4
            mMP = (locMagBase * mSPR * mLVL) * 2
        ElseIf rbTypeEndBoss.IsChecked Then
            mHP = (locHitBase * mVIT * mLVL) * 6
            mMP = (locMagBase * mSPR * mLVL) * 3
        End If

        tbCreateMonsterHP.Text = mHP
        tbCreateMonsterMP.Text = mMP
    End Sub
    Private Sub GetCombatStats()
        Dim locArmorBase As Double
        Dim locMArmorBase As Double

        If rbArmBase05.IsChecked Then
            locArmorBase = 0.5
        ElseIf rbArmBase10.IsChecked Then
            locArmorBase = 1.0
        ElseIf rbArmBase20.IsChecked Then
            locArmorBase = 2.0
        ElseIf rbArmBase40.IsChecked Then
            locArmorBase = 4.0
        ElseIf rbArmBase60.IsChecked Then
            locArmorBase = 6.0
        End If

        If rbMArmBase05.IsChecked Then
            locMArmorBase = 0.5
        ElseIf rbMArmBase10.IsChecked Then
            locMArmorBase = 1.0
        ElseIf rbMArmBase20.IsChecked Then
            locMArmorBase = 2.0
        ElseIf rbMArmBase40.IsChecked Then
            locMArmorBase = 4.0
        ElseIf rbMArmBase60.IsChecked Then
            locMArmorBase = 6.0
        End If

        mACC = (80 + mLVL + (mAGI * 2))
        mMACC = (100 + mLVL + (mMAG * 2))
        mDEX = (50 + mLVL + (mAGI * 2))
        mMND = (50 + mLVL + (mMAG * 2))
        mARM = (locArmorBase * mLVL + (mVIT / 2))
        mMARM = (locMArmorBase * mLVL + (mSPR / 2))
        mEVA = (mLVL + mSPD + mAGI)
        mMEVA = (mLVL + mMAG + mSPR)

        tbCreateMonsterACC.Text = mACC
        tbCreateMonsterMACC.Text = mMACC
        tbCreateMonsterDEX.Text = mDEX
        tbCreateMonsterMIND.Text = mMND
        tbCreateMonsterARM.Text = mARM
        tbCreateMonsterMARM.Text = mMARM
        tbCreateMonsterEVA.Text = mEVA
        tbCreateMonsterMEVA.Text = mMEVA
    End Sub
    Private Sub GetDamage()
        Dim locDamageDie As Integer
        Dim locDamageMultiplier As Integer
        Dim locDieNum As Integer = 1

        If rbDamDie6.IsChecked Then
            locDamageDie = 6
        ElseIf rbDamDie8.IsChecked Then
            locDamageDie = 8
        ElseIf rbDamDie10.IsChecked Then
            locDamageDie = 10
        ElseIf rbDamDIe12.IsChecked Then
            locDamageDie = 12
        End If

        If mLVL >= 1 And mLVL <= 4 Then
            locDamageMultiplier = 2
            locDieNum = 1
        ElseIf mLVL >= 5 And mLVL <= 9 Then
            Select Case locDamageDie
                Case 6
                    locDamageMultiplier = 2
                    locDieNum = 1
                Case 8
                    locDamageMultiplier = 3
                    locDieNum = 1
                Case 10
                    locDamageMultiplier = 3
                    locDieNum = 1
                Case 12
                    locDamageMultiplier = 3
                    locDieNum = 1
            End Select
        ElseIf mLVL >= 10 And mLVL <= 14 Then
            Select Case locDamageDie
                Case 6
                    locDamageMultiplier = 3
                    locDieNum = 1
                Case 8
                    locDamageMultiplier = 3
                    locDieNum = 1
                Case 10
                    locDamageMultiplier = 4
                    locDieNum = 1
                Case 12
                    locDamageMultiplier = 4
                    locDieNum = 1
            End Select
        ElseIf mLVL >= 15 And mLVL <= 19 Then
            Select Case locDamageDie
                Case 6
                    locDamageMultiplier = 4
                    locDieNum = 2
                Case 8
                    locDamageMultiplier = 4
                    locDieNum = 2
                Case 10
                    locDamageMultiplier = 5
                    locDieNum = 1
                Case 12
                    locDamageMultiplier = 6
                    locDieNum = 1
            End Select
        ElseIf mLVL >= 20 And mLVL <= 24 Then
            Select Case locDamageDie
                Case 6
                    locDamageMultiplier = 5
                    locDieNum = 3
                Case 8
                    locDamageMultiplier = 5
                    locDieNum = 2
                Case 10
                    locDamageMultiplier = 6
                    locDieNum = 1
                Case 12
                    locDamageMultiplier = 7
                    locDieNum = 1
            End Select
        ElseIf mLVL >= 25 And mLVL <= 29 Then
            Select Case locDamageDie
                Case 6
                    locDamageMultiplier = 5
                    locDieNum = 3
                Case 8
                    locDamageMultiplier = 6
                    locDieNum = 2
                Case 10
                    locDamageMultiplier = 7
                    locDieNum = 1
                Case 12
                    locDamageMultiplier = 8
                    locDieNum = 1
            End Select
        ElseIf mLVL >= 30 And mLVL <= 34 Then
            Select Case locDamageDie
                Case 6
                    locDamageMultiplier = 6
                    locDieNum = 3
                Case 8
                    locDamageMultiplier = 7
                    locDieNum = 2
                Case 10
                    locDamageMultiplier = 8
                    locDieNum = 2
                Case 12
                    locDamageMultiplier = 9
                    locDieNum = 1
            End Select
        ElseIf mLVL >= 35 And mLVL <= 39 Then
            Select Case locDamageDie
                Case 6
                    locDamageMultiplier = 7
                    locDieNum = 3
                Case 8
                    locDamageMultiplier = 8
                    locDieNum = 3
                Case 10
                    locDamageMultiplier = 9
                    locDieNum = 2
                Case 12
                    locDamageMultiplier = 10
                    locDieNum = 2
            End Select
        ElseIf mLVL >= 40 And mLVL <= 44 Then
            Select Case locDamageDie
                Case 6
                    locDamageMultiplier = 8
                    locDieNum = 3
                Case 8
                    locDamageMultiplier = 9
                    locDieNum = 3
                Case 10
                    locDamageMultiplier = 10
                    locDieNum = 2
                Case 12
                    locDamageMultiplier = 11
                    locDieNum = 2
            End Select
        ElseIf mLVL >= 45 And mLVL <= 49 Then
            Select Case locDamageDie
                Case 6
                    locDamageMultiplier = 9
                    locDieNum = 4
                Case 8
                    locDamageMultiplier = 10
                    locDieNum = 3
                Case 10
                    locDamageMultiplier = 11
                    locDieNum = 3
                Case 12
                    locDamageMultiplier = 12
                    locDieNum = 2
            End Select
        ElseIf mLVL >= 50 And mLVL <= 54 Then
            Select Case locDamageDie
                Case 6
                    locDamageMultiplier = 10
                    locDieNum = 4
                Case 8
                    locDamageMultiplier = 11
                    locDieNum = 4
                Case 10
                    locDamageMultiplier = 13
                    locDieNum = 3
                Case 12
                    locDamageMultiplier = 15
                    locDieNum = 3
            End Select
        ElseIf mLVL >= 55 And mLVL <= 59 Then
            Select Case locDamageDie
                Case 6
                    locDamageMultiplier = 11
                    locDieNum = 4
                Case 8
                    locDamageMultiplier = 12
                    locDieNum = 4
                Case 10
                    locDamageMultiplier = 15
                    locDieNum = 3
                Case 12
                    locDamageMultiplier = 17
                    locDieNum = 3
            End Select
        ElseIf mLVL >= 60 And mLVL <= 64 Then
            Select Case locDamageDie
                Case 6
                    locDamageMultiplier = 12
                    locDieNum = 5
                Case 8
                    locDamageMultiplier = 13
                    locDieNum = 4
                Case 10
                    locDamageMultiplier = 16
                    locDieNum = 4
                Case 12
                    locDamageMultiplier = 18
                    locDieNum = 3
            End Select
        ElseIf mLVL >= 65 And mLVL <= 69 Then
            Select Case locDamageDie
                Case 6
                    locDamageMultiplier = 13
                    locDieNum = 5
                Case 8
                    locDamageMultiplier = 14
                    locDieNum = 5
                Case 10
                    locDamageMultiplier = 17
                    locDieNum = 4
                Case 12
                    locDamageMultiplier = 19
                    locDieNum = 4
            End Select
        ElseIf mLVL >= 70 And mLVL <= 74 Then
            Select Case locDamageDie
                Case 6
                    locDamageMultiplier = 14
                    locDieNum = 5
                Case 8
                    locDamageMultiplier = 15
                    locDieNum = 5
                Case 10
                    locDamageMultiplier = 20
                    locDieNum = 4
                Case 12
                    locDamageMultiplier = 21
                    locDieNum = 4
            End Select
        ElseIf mLVL >= 75 And mLVL <= 79 Then
            Select Case locDamageDie
                Case 6
                    locDamageMultiplier = 15
                    locDieNum = 5
                Case 8
                    locDamageMultiplier = 16
                    locDieNum = 5
                Case 10
                    locDamageMultiplier = 21
                    locDieNum = 5
                Case 12
                    locDamageMultiplier = 23
                    locDieNum = 4
            End Select
        ElseIf mLVL >= 80 And mLVL <= 84 Then
            Select Case locDamageDie
                Case 6
                    locDamageMultiplier = 16
                    locDieNum = 5
                Case 8
                    locDamageMultiplier = 18
                    locDieNum = 5
                Case 10
                    locDamageMultiplier = 22
                    locDieNum = 5
                Case 12
                    locDamageMultiplier = 24
                    locDieNum = 5
            End Select
        ElseIf mLVL >= 85 And mLVL <= 89 Then
            Select Case locDamageDie
                Case 6
                    locDamageMultiplier = 17
                    locDieNum = 5
                Case 8
                    locDamageMultiplier = 19
                    locDieNum = 5
                Case 10
                    locDamageMultiplier = 23
                    locDieNum = 5
                Case 12
                    locDamageMultiplier = 25
                    locDieNum = 5
            End Select
        ElseIf mLVL >= 90 And mLVL <= 94 Then
            Select Case locDamageDie
                Case 6
                    locDamageMultiplier = 18
                    locDieNum = 5
                Case 8
                    locDamageMultiplier = 21
                    locDieNum = 5
                Case 10
                    locDamageMultiplier = 24
                    locDieNum = 5
                Case 12
                    locDamageMultiplier = 26
                    locDieNum = 5
            End Select
        ElseIf mLVL >= 95 And mLVL <= 98 Then
            Select Case locDamageDie
                Case 6
                    locDamageMultiplier = 19
                    locDieNum = 5
                Case 8
                    locDamageMultiplier = 22
                    locDieNum = 5
                Case 10
                    locDamageMultiplier = 25
                    locDieNum = 5
                Case 12
                    locDamageMultiplier = 27
                    locDieNum = 5
            End Select
        ElseIf mLVL = 99 Then
            Select Case locDamageDie
                Case 6
                    locDamageMultiplier = 20
                    locDieNum = 5
                Case 8
                    locDamageMultiplier = 23
                    locDieNum = 5
                Case 10
                    locDamageMultiplier = 26
                    locDieNum = 5
                Case 12
                    locDamageMultiplier = 29
                    locDieNum = 5
            End Select
        End If

        Dim Attribute As String
        If mSTR > mAGI Then Attribute = "STR" Else Attribute = "AGI"
        DamageText = locDamageMultiplier & " x " & Attribute & " + " & locDieNum & "D" & locDamageDie
    End Sub

    Private Treasure() As String

    Private Sub btnOpenTreasure_Click(sender As Object, e As RoutedEventArgs) Handles btnOpenTreasure.Click
        Dim TreasureCount As Integer = rn.Next Mod 4 + 1
        Dim TreasureType As Integer = 0
        Dim TreasureRoll As Integer = 0
        Dim TreasureText As String = ""

        'LEGENDARY 0
        'ARTIFACT 1-3
        'EPIC 4-10
        'RARE 11-22
        'UNCOMMON 23-40
        'COMMON ELSE

        For i = 0 To TreasureCount
            TreasureType = rn.Next Mod 4
            TreasureRoll = rn.Next Mod 100

            If TreasureRoll = 0 Then TreasureText = "Legendary"
            If TreasureRoll >= 1 And TreasureRoll <= 3 Then TreasureText = "Artifact"
            If TreasureRoll >= 4 And TreasureRoll <= 10 Then TreasureText = "Epic"
            If TreasureRoll >= 11 And TreasureRoll <= 22 Then TreasureText = "Rare"
            If TreasureRoll >= 23 And TreasureRoll <= 40 Then TreasureText = "Uncommon"
            If TreasureRoll >= 41 Then TreasureText = "Common"

            If TreasureType = 0 Then TreasureText = TreasureText + " Item"
            If TreasureType = 1 Then TreasureText = TreasureText + " Recovery"
            If TreasureType = 2 Then TreasureText = TreasureText + " Weapon"
            If TreasureType = 3 Then TreasureText = TreasureText + " Armor"

            lbTreasure.Items.Add(TreasureText)
        Next
    End Sub

    Private Sub btnClearTreasure_Click(sender As Object, e As RoutedEventArgs) Handles btnClearTreasure.Click
        lbTreasure.Items.Clear()
    End Sub

    Private Sub btnCreateMonster_Click(sender As Object, e As RoutedEventArgs) Handles btnCreateMonster.Click
        Dim m As Monster
        Dim mGilMod, mExpMod As Integer
        If IsNumeric(tbMonsterQuantity.Text) And tbMonsterName.Text <> "" Then
            GetGilEXP(mGilMod, mExpMod)
            For i = 1 To CInt(tbMonsterQuantity.Text)
                m = New Monster(tbMonsterName.Text & "_" & i, mHP, mMP, mSTR, mVIT, mSPD, mAGI, mMAG, mSPR, mACC, mMACC, mDEX,
                                mMND, mARM, mMARM, mEVA, mMEVA, mGilMod, mExpMod, DamageText, mCreateEnemyMagic, GetRandomRewards())
                AddMonster(m)
            Next
        End If
        CleanUpLastEnemyCreate()
    End Sub
    Private Sub AddMagicToArray(ByVal mag As Magic)
        If mCreateEnemyMagic Is Nothing Then
            ReDim mCreateEnemyMagic(0)
            mCreateEnemyMagic(0) = mag
        Else
            ReDim Preserve mCreateEnemyMagic(UBound(mCreateEnemyMagic) + 1)
            mCreateEnemyMagic(UBound(mCreateEnemyMagic)) = mag
        End If
    End Sub
    Private Sub RemoveMagicFromArray(ByVal SpellName As String)
        For i = 0 To UBound(mCreateEnemyMagic)
            If mCreateEnemyMagic(i).SpellName = SpellName Then
                'remove this instance
                mCreateEnemyMagic(i) = Nothing
                For j = i To UBound(mCreateEnemyMagic) - 1
                    mCreateEnemyMagic(j) = mCreateEnemyMagic(j + 1)
                Next
                ReDim Preserve mCreateEnemyMagic(UBound(mCreateEnemyMagic) - 1)
                Exit Sub
            End If
        Next
    End Sub
    Private Sub btnAddEnemySpells_Click(sender As Object, e As RoutedEventArgs) Handles btnAddEnemySpells.Click
        Select Case tcDataGridMagic.SelectedIndex
            Case 0
                For i = 0 To dgvCreateEnemyBlackMagic.SelectedItems.Count - 1
                    With dgvCreateEnemyBlackMagic.SelectedItems(i)
                        Dim m As New Magic(CInt(.Item(0).ToString), .Item(1).ToString, .Item(2).ToString, CInt(.Item(3).ToString), .Item(4).ToString, .Item(5).ToString)
                        AddMagicToArray(m)
                        lbCreateEnemySpells.Items.Add(m.SpellName)
                    End With
                Next
            Case 1
                For i = 0 To dgvCreateEnemyWhiteMagic.SelectedItems.Count - 1
                    With dgvCreateEnemyWhiteMagic.SelectedItems(i)
                        Dim m As New Magic(CInt(.Item(0).ToString), .Item(1).ToString, .Item(2).ToString, CInt(.Item(3).ToString), .Item(4).ToString, .Item(5).ToString)
                        AddMagicToArray(m)
                        lbCreateEnemySpells.Items.Add(m.SpellName)
                    End With
                Next
            Case 2
                For i = 0 To dgvCreateEnemyTimeMagic.SelectedItems.Count - 1
                    With dgvCreateEnemyTimeMagic.SelectedItems(i)
                        Dim m As New Magic(CInt(.Item(0).ToString), .Item(1).ToString, .Item(2).ToString, CInt(.Item(3).ToString), .Item(4).ToString, .Item(5).ToString)
                        AddMagicToArray(m)
                        lbCreateEnemySpells.Items.Add(m.SpellName)
                    End With
                Next
        End Select
    End Sub
    Private Sub CleanUpLastEnemyCreate()
        mCreateEnemyMagic = Nothing
        lbCreateEnemySpells.Items.Clear()
    End Sub
    Private Sub btnRemoveEnemySpells_Click(sender As Object, e As RoutedEventArgs) Handles btnRemoveEnemySpells.Click
        With lbCreateEnemySpells
            While .SelectedItems.Count > 0
                RemoveMagicFromArray(.SelectedItem.ToString)
                .Items.Remove(.SelectedItem)
            End While
        End With
        lbCreateEnemySpells.Items.Refresh()
    End Sub

    Private Sub GetGilEXP(ByRef mGilMod As Integer, ByRef mExpMod As Integer)
        GetGilExpNotoriety(mGilMod, mExpMod)
        GetGilExpHPMP(mGilMod, mExpMod)
        GetGilExpCombatStats(mGilMod, mExpMod)
        GetGilExpDamage(mGilMod, mExpMod)
        If mCreateEnemyMagic IsNot Nothing Then
            For i = 0 To UBound(mCreateEnemyMagic)
                GetGilExpMagic(mCreateEnemyMagic(i).Level, mGilMod, mExpMod)
            Next
        End If
        mGilMod *= mLVL
        mExpMod *= mLVL
    End Sub
    Private Sub GetGilExpNotoriety(ByRef mGilMod As Integer, ByRef mEXPMod As Integer)
        If rbTypeRegular.IsChecked Then
            mGilMod = 15
            mEXPMod = 40
        End If

        If rbTypeNotorious.IsChecked Then
            mGilMod = 25
            mEXPMod = 100
        End If

        If rbTypeBoss.IsChecked Then
            mGilMod = 55
            mEXPMod = 225
        End If

        If rbTypeEndBoss.IsChecked Then
            mGilMod = 90
            mEXPMod = 350
        End If
    End Sub
    Private Sub GetGilExpHPMP(ByRef mGilMod As Integer, ByRef mEXPMod As Integer)
        If rbHitBase10.IsChecked Then
            mEXPMod += -16
            mGilMod += -6
        ElseIf rbHitBase15.IsChecked Then
            mEXPMod += -8
            mGilMod += -3
        ElseIf rbHitBase20.IsChecked Then
            mEXPMod += 0
            mGilMod += 0
        ElseIf rbHitBase40.IsChecked Then
            mEXPMod += 18
            mGilMod += 8
        ElseIf rbHitBase60.IsChecked Then
            mEXPMod += 40
            mGilMod += 19
        ElseIf rbHitBase80.IsChecked Then
            mEXPMod += 60
            mGilMod += 30
        End If

        If rbMagBase00.IsChecked Then
            mEXPMod += 0
            mGilMod += 0
        ElseIf rbMagBase05.IsChecked Then
            mEXPMod += 8
            mGilMod += 3
        ElseIf rbMagBase10.IsChecked Then
            mEXPMod += 15
            mGilMod += 7
        ElseIf rbMagBase15.IsChecked Then
            mEXPMod += 22
            mGilMod += 10
        ElseIf rbMagBase20.IsChecked Then
            mEXPMod += 35
            mGilMod += 16
        ElseIf rbMagBase40.IsChecked Then
            mEXPMod += 50
            mGilMod += 28
        End If
    End Sub
    Private Sub GetGilExpCombatStats(ByRef mGilMod As Integer, ByRef mEXPMod As Integer)
        If rbArmBase05.IsChecked Then
            mEXPMod += -5
            mGilMod += -2
        ElseIf rbArmBase10.IsChecked Then
            mEXPMod += 0
            mGilMod += 0
        ElseIf rbArmBase20.IsChecked Then
            mEXPMod += 10
            mGilMod += 5
        ElseIf rbArmBase40.IsChecked Then
            mEXPMod += 19
            mGilMod += 9
        ElseIf rbArmBase60.IsChecked Then
            mEXPMod += 26
            mGilMod += 18
        End If

        If rbMArmBase05.IsChecked Then
            mEXPMod += -5
            mGilMod += -2
        ElseIf rbMArmBase10.IsChecked Then
            mEXPMod += 0
            mGilMod += 0
        ElseIf rbMArmBase20.IsChecked Then
            mEXPMod += 10
            mGilMod += 5
        ElseIf rbMArmBase40.IsChecked Then
            mEXPMod += 19
            mGilMod += 9
        ElseIf rbMArmBase60.IsChecked Then
            mEXPMod += 26
            mGilMod += 18
        End If
    End Sub
    Private Sub GetGilExpDamage(ByRef mGilMod As Integer, ByRef mEXPMod As Integer)
        If rbDamDie6.IsChecked Then
            mEXPMod += 8
            mGilMod += 3
        ElseIf rbDamDie8.IsChecked Then
            mEXPMod += 20
            mGilMod += 8
        ElseIf rbDamDie10.IsChecked Then
            mEXPMod += 30
            mGilMod += 10
        ElseIf rbDamDIe12.IsChecked Then
            mEXPMod += 60
            mGilMod += 20
        End If
    End Sub
    Private Sub GetGilExpMagic(ByVal Level As Integer, ByRef mGilMod As Integer, ByRef mExpMod As Integer)
        Select Case Level
            Case 1
                mExpMod += 8
                mGilMod += 5
            Case 2
                mExpMod += 15
                mGilMod += 9
            Case 3
                mExpMod += 25
                mGilMod += 14
            Case 4
                mExpMod += 33
                mGilMod += 21
            Case 5
                mExpMod += 45
                mGilMod += 30
            Case 6
                mExpMod += 55
                mGilMod += 37
            Case 7
                mExpMod += 64
                mGilMod += 44
            Case 8
                mExpMod += 80
                mGilMod += 55
        End Select
    End Sub

    Dim rn As New Random
    Private Function GetRandomRewards() As DroppedItem()
        Dim mTreasureTable(3) As DroppedItem
        Dim BaseAvailability As Integer = 100 - mLVL

        'Get First Item (Common)
        BaseAvailability = 100 - (mLVL / 2)
        mTreasureTable(0) = GetItemFromTreasureTableItems(rn.Next(0, UBound(TreasureTableItems)), BaseAvailability - rn.Next(0, 5) + 5)
        mTreasureTable(0).Roll = "51-100"

        'Get Second Item (Uncommon)
        BaseAvailability = 100 - (mLVL / 1.5)
        mTreasureTable(1) = GetItemFromTreasureTableItems(rn.Next(0, UBound(TreasureTableItems)), BaseAvailability - rn.Next(0, 5) - 0)
        mTreasureTable(1).Roll = "25-50"

        'Get Third Item (Rare)
        BaseAvailability = 100 - (mLVL / 1.2)
        mTreasureTable(2) = GetItemFromTreasureTableItems(rn.Next(0, UBound(TreasureTableItems)), BaseAvailability - rn.Next(0, 5) - 5)
        mTreasureTable(2).Roll = "08-24"

        'Get Fourth Item (Very Rare)
        BaseAvailability = 100 - mLVL
        mTreasureTable(3) = GetItemFromTreasureTableItems(rn.Next(0, UBound(TreasureTableItems)), BaseAvailability - rn.Next(0, 5) - 10)
        mTreasureTable(3).Roll = "01-07"

        Return mTreasureTable
    End Function
    Private Function GetItemFromTreasureTableItems(ByVal Seed As Integer, ByVal Avail As Integer) As DroppedItem
        Dim Difference As Integer = 2
        If Avail < 0 Then Avail = 0

        For i = Seed To UBound(TreasureTableItems)
            With TreasureTableItems(i)
                If .Availability > Avail - Difference And .Availability < Avail + Difference Then
                    Return TreasureTableItems(i)
                End If
            End With
        Next
        For i = 0 To Seed - 1
            With TreasureTableItems(i)
                If .Availability > Avail - Difference And .Availability < Avail + Difference Then
                    Return TreasureTableItems(i)
                End If
            End With
        Next
        Return New DroppedItem
    End Function
#End Region
End Class
