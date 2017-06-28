Public Class Monster
    Private mName As String
    Private mML As Integer

    Private mHPMax As Integer
    Private mHPCurrent As Integer
    Private mMPMax As Integer
    Private mMPCurrent As Integer

    Private mSTR As Integer
    Private mVIT As Integer
    Private mSPD As Integer
    Private mAGI As Integer
    Private mMAG As Integer
    Private mSPR As Integer

    Private mAccuracy As Integer
    Private mMagicAccuracy As Integer
    Private mDexterity As Integer
    Private mMind As Integer
    Private mArmor As Integer
    Private mMagicArmor As Integer
    Private mEvasion As Integer
    Private mMagicEvasion As Integer

    Private mGilMod As Integer
    Private mXPMod As Integer

    Private mDamageText As String

    Private tSTR As Integer
    Private tVIT As Integer
    Private tSPD As Integer
    Private tAGI As Integer
    Private tMAG As Integer
    Private tSPR As Integer

    Private tAccuracy As Integer
    Private tMagicAccuracy As Integer
    Private tDexterity As Integer
    Private tMind As Integer
    Private tArmor As Integer
    Private tMagicArmor As Integer
    Private tEvasion As Integer
    Private tMagicEvasion As Integer

    Private mMagic() As Magic
    Private mTreasureTable() As DroppedItem

    Public Sub New(ByVal Name As String, ByVal HP As Integer, ByVal MP As Integer, ByVal STR As Integer, ByVal VIT As Integer, ByVal SPD As Integer, ByVal AGI As Integer, _
                   ByVal MAG As Integer, ByVal SPR As Integer, ByVal Accuracy As Integer, ByVal MagicAccuracy As Integer, ByVal Dexterity As Integer, _
                   ByVal Mind As Integer, ByVal Armor As Integer, ByVal MagicArmor As Integer, ByVal Evasion As Integer, ByVal MagicEvasion As Integer, _
                   ByVal GilMod As Integer, ByVal XPMod As Integer, ByVal DamageText As String, ByVal Magic() As Magic, ByVal Treasure() As DroppedItem)
        mName = Name
        mHPCurrent = HP
        mMPCurrent = MP
        mHPMax = HP
        mMPMax = MP
        mSTR = STR
        mVIT = VIT
        mSPD = SPD
        mAGI = AGI
        mMAG = MAG
        mSPR = SPR
        mAccuracy = Accuracy
        mMagicAccuracy = MagicAccuracy
        mDexterity = Dexterity
        mMind = Mind
        mArmor = Armor
        mMagicArmor = MagicArmor
        mEvasion = Evasion
        mMagicEvasion = MagicEvasion
        mGilMod = GilMod
        mXPMod = XPMod
        mDamageText = DamageText

        tSTR = STR
        tVIT = VIT
        tSPD = SPD
        tAGI = AGI
        tMAG = MAG
        tSPR = SPR
        tAccuracy = Accuracy
        tMagicAccuracy = MagicAccuracy
        tDexterity = Dexterity
        tMind = Mind
        tArmor = Armor
        tMagicArmor = MagicArmor
        tEvasion = Evasion
        tMagicEvasion = MagicEvasion

        mMagic = Magic
        mTreasureTable = Treasure
    End Sub

#Region "GETTERS"
    Friend Function GetName() As String
        Return mName
    End Function

    Friend Function GetMaxHP() As Integer
        Return mHPMax
    End Function

    Friend Function GetCurrentHP() As Integer
        Return mHPCurrent
    End Function

    Friend Function GetMaxMP() As Integer
        Return mMPMax
    End Function

    Friend Function GetCurrentMP() As Integer
        Return mMPCurrent
    End Function

    Friend Function GetSTR() As Integer
        Return tSTR
    End Function

    Friend Function GetVIT() As Integer
        Return tVIT
    End Function

    Friend Function GetSPD() As Integer
        Return tSPD
    End Function

    Friend Function GetAGI() As Integer
        Return tAGI
    End Function

    Friend Function GetMAG() As Integer
        Return tMAG
    End Function

    Friend Function GetSPR() As Integer
        Return tSPR
    End Function

    Friend Function GetAccuracy() As Integer
        Return tAccuracy
    End Function

    Friend Function GetMagicAccuracy() As Integer
        Return tMagicAccuracy
    End Function

    Friend Function GetDexterity() As Integer
        Return tDexterity
    End Function

    Friend Function GetMind() As Integer
        Return tMind
    End Function

    Friend Function GetArmor() As Integer
        Return tArmor
    End Function

    Friend Function GetMagicArmor() As Integer
        Return tMagicArmor
    End Function

    Friend Function GetEvasion() As Integer
        Return tEvasion
    End Function

    Friend Function GetMagicEvasion() As Integer
        Return tMagicEvasion
    End Function

    Friend Function GetXPModifier() As Integer
        Return mXPMod
    End Function

    Friend Function GetGilModifier() As Integer
        Return mGilMod
    End Function

    Friend Function GetDamageText() As String
        Return mDamageText
    End Function
#End Region

#Region "SETTERS"
    Friend Sub SetName(ByVal Name As String)
        mName = Name
    End Sub

    Friend Sub SetMaxHP(ByVal HP As Integer)
        mHPMax = HP
    End Sub

    Friend Sub SetMaxMP(ByVal MP As Integer)
        mMPMax = MP
    End Sub

    Friend Sub SetSTR(ByVal STR As Integer)
        mSTR = STR
    End Sub

    Friend Sub SetVIT(ByVal VIT As Integer)
        mVIT = VIT
    End Sub

    Friend Sub SetSPD(ByVal SPD As Integer)
        mSPD = SPD
    End Sub

    Friend Sub SetAGI(ByVal AGI As Integer)
        mAGI = AGI
    End Sub

    Friend Sub SetMAG(ByVal MAG As Integer)
        mMAG = MAG
    End Sub

    Friend Sub SetSPR(ByVal SPR As Integer)
        mSPR = SPR
    End Sub

    Friend Sub SetAccuracy(ByVal Accuracy As Integer)
        mAccuracy = Accuracy
    End Sub

    Friend Sub SetMagicAccuracy(ByVal MagicAccuracy As Integer)
        mMagicAccuracy = MagicAccuracy
    End Sub

    Friend Sub SetDexterity(ByVal Dexterity As Integer)
        mDexterity = Dexterity
    End Sub

    Friend Sub SetMind(ByVal Mind As Integer)
        mMind = Mind
    End Sub

    Friend Sub SetArmor(ByVal Armor As Integer)
        mArmor = Armor
    End Sub

    Friend Sub SetMagicArmor(ByVal MagicArmor As Integer)
        mMagicArmor = MagicArmor
    End Sub

    Friend Sub SetEvasion(ByVal Evasion As Integer)
        mEvasion = Evasion
    End Sub

    Friend Sub SetMagicEvasion(ByVal MagicEvasion As Integer)
        mMagicEvasion = MagicEvasion
    End Sub

    Friend Sub SetGilMod(ByVal GilMod As Integer)
        mGilMod = GilMod
    End Sub

    Friend Sub SetXPMod(ByVal XPMod As Integer)
        mXPMod = XPMod
    End Sub

    Friend Sub SetDamageText(ByVal DamageText As String)
        mDamageText = DamageText
    End Sub
#End Region

#Region "HP/MP MATH"
    Friend Sub SetCurrentHP(ByVal HP As Integer)
        mHPCurrent = HP
    End Sub
    Friend Sub AddHP(ByVal HP As Integer)
        If mHPCurrent + HP >= mHPMax Then
            mHPCurrent = mHPMax
        Else
            mHPCurrent += HP
        End If
    End Sub
    Friend Sub SubtractHP(ByVal HP As Integer)
        If mHPCurrent - HP <= 0 Then
            mHPCurrent = 0
        Else
            mHPCurrent -= HP
        End If
    End Sub
    Friend Sub SetCurrentMP(ByVal MP As Integer)
        mMPCurrent = MP
    End Sub
    Friend Sub AddMP(ByVal MP As Integer)
        If mMPCurrent + MP > mMPMax Then
            mMPCurrent = mMPMax
        Else
            mMPCurrent += MP
        End If
    End Sub
    Friend Sub SubtractMP(ByVal MP As Integer)
        If mMPCurrent - MP <= 0 Then
            mMPCurrent = 0
        Else
            mMPCurrent -= MP
        End If
    End Sub
#End Region

#Region "STATUS EFFECTS"
    Private MonsterStatusEffects As New StatusEffect

    Friend Sub AddStatus(ByVal Status As String, ByVal Duration As Integer)
        MonsterStatusEffects.AddStatus(Status, Duration)
        InitializeBuffsDebuffs(Status)
    End Sub

    Friend Sub InitializeBuffsDebuffs(ByVal Str As String)
        With MonsterStatusEffects
            Select Case Str
                Case "AgilityBreak"
                    If .sAgilityDownDuration > 0 Then
                        .sAgilityDownDuration = 0
                        tEvasion += mEvasion * 0.25
                        tAccuracy += mAccuracy * 0.25
                    End If
                    tEvasion -= mEvasion * 0.5
                    tAccuracy -= mAccuracy * 0.5
                Case "AgilityDown"
                    If .sAgilityBreakDuration > 0 Then
                        .sAgilityBreakDuration = 0
                        tEvasion += mEvasion * 0.5
                        tAccuracy += mAccuracy * 0.5
                    End If

                    tEvasion -= mEvasion * 0.25
                    tAccuracy -= mAccuracy * 0.25
                Case "ArmorBreak"
                    If .sArmorDownDuration > 0 Then
                        .sArmorDownDuration = 0
                        tArmor += mArmor * 0.25
                    End If
                    tArmor -= mArmor * 0.5
                Case "ArmorDown"
                    If .sArmorBreakDuration > 0 Then
                        .sArmorBreakDuration = 0
                        tArmor += mArmor * 0.5
                    End If
                    tArmor -= mArmor * 0.25
                Case "Lock"
                    tEvasion -= 20
                    tMagicEvasion -= 20
                Case "MagicBreak"
                    .sMagicDownDuration = 0
                    .sMagicUpDuration = 0
                Case "MagicDown"
                    .sMagicBreakDuration = 0
                    .sMagicUpDuration = 0
                Case "Meltdown"
                    tArmor = 0
                    tMagicArmor = 0
                Case "MentalBreak"
                    If .sMentalDownDuration > 0 Then
                        .sMentalDownDuration = 0
                        tMagicArmor += mMagicArmor * 0.25
                    End If
                    tMagicArmor -= mMagicArmor * 0.5
                Case "MentalDown"
                    If .sMentalBreakDuration > 0 Then
                        .sMentalBreakDuration = 0
                        tMagicArmor += mMagicArmor * 0.5
                    End If
                    tMagicArmor -= mMagicArmor * 0.25
                Case "PowerBreak"
                    .sPowerDownDuration = 0
                Case "PowerDown"
                    .sPowerBreakDuration = 0
                Case "SpiritBreak"
                    If .sSpiritDownDuration > 0 Then
                        .sSpiritDownDuration = 0
                        tMagicAccuracy += mMagicAccuracy * 0.25
                        tMagicEvasion += mMagicEvasion * 0.25
                    End If
                    tMagicAccuracy -= mMagicAccuracy * 0.5
                    tMagicEvasion -= mMagicEvasion * 0.5
                Case "SpiritDown"
                    If .sSpiritBreakDuration > 0 Then
                        .sSpiritBreakDuration = 0
                        tMagicAccuracy += mMagicAccuracy * 0.5
                        tMagicEvasion += mMagicEvasion * 0.5
                    End If
                    tMagicAccuracy -= mMagicAccuracy * 0.25
                    tMagicEvasion -= mMagicEvasion * 0.25
                Case "Accelerate"
                    tSPD = tSPD * 2
                Case "AccuracyUp"
                    tAccuracy = 255
                Case "AgilityUp"
                    tEvasion += mEvasion * 0.25
                    tAccuracy += mAccuracy * 0.25
                Case "ArmorUp"
                    If .sArmorBreakDuration > 0 Then
                        .sArmorBreakDuration = 0
                        tArmor += mArmor * 0.5
                    End If
                    If .sArmorDownDuration > 0 Then
                        .sArmorDownDuration = 0
                        tArmor += mArmor * 0.25
                    End If
                    tArmor += mArmor * 0.25
                Case "Blink"
                    tEvasion += 20
                Case "MagicUp"
                Case "MentalUp"
                    tMagicArmor += mMagicArmor * 0.25
                Case "Ruse"
                    tEvasion += 40
                Case "SpiritUp"
                    tMagicEvasion += mMagicEvasion * 0.25
                    tMagicAccuracy += mMagicAccuracy * 0.25
            End Select
        End With
    End Sub

    Friend Sub StatusCleanup()
        'tSTR = mSTR
        'tVIT = mVIT
        'tSPD = mSPD
        'tAGI = mAGI
        'tMAG = mMAG
        'tSPR = mSPR

        'tEvasion = mEvasion
        'tMagicEvasion = mMagicEvasion
        'tAccuracy = mAccuracy
        'tMagicAccuracy = mMagicAccuracy
        'tArmor = mArmor
        'tMagicArmor = mMagicArmor
        'tMind = mMind
        'tDexterity = mDexterity

        With MonsterStatusEffects
            If .sPoisonDuration > 0 Then
                SubtractHP(mHPCurrent / 10)
            End If
            If .sVenomDuration > 0 Then
                SubtractHP(mHPCurrent / 10)
                SubtractMP(mMPCurrent / 10)
            End If
            If .sCondemnedDuration > 0 Then .sCondemnedDuration -= 1
            If .sDeathDuration > 0 Then .sDeathDuration -= 1
            If .sEjectDuration > 0 Then .sEjectDuration -= 1
            If .sFrozeDuration > 0 Then .sFrozeDuration -= 1
            If .sHeatDuration > 0 Then .sHeatDuration -= 1

            If .sBerserkDuration > 0 Then .sBerserkDuration -= 1
            If .sCharmDuration > 0 Then .sCharmDuration -= 1
            If .sConfuseDuration > 0 Then .sConfuseDuration -= 1
            If .sUnawareDuration > 0 Then .sUnawareDuration -= 1

            If .sPoisonDuration > 0 Then .sPoisonDuration -= 1
            If .sVenomDuration > 0 Then .sVenomDuration -= 1

            If .sBlindDuration > 0 Then .sBlindDuration -= 1
            If .sCurseDuration > 0 Then .sCurseDuration -= 1
            If .sPetrifyDuration > 0 Then .sPetrifyDuration -= 1
            If .sSilenceDuration > 0 Then .sSilenceDuration -= 1
            If .sSleepDuration > 0 Then .sSleepDuration -= 1
            If .sStoneDuration > 0 Then .sStoneDuration -= 1

            If .sDisableDuration > 0 Then .sDisableDuration -= 1
            If .sImmobilizeDuration > 0 Then .sImmobilizeDuration -= 1
            If .sSapDuration > 0 Then .sSapDuration -= 1
            If .sSlowDuration > 0 Then .sSlowDuration -= 1
            If .sStopDuration > 0 Then .sStopDuration -= 1

            If .sMiniDuration > 0 Then .sMiniDuration -= 1
            If .sToadDuration > 0 Then .sToadDuration -= 1
            If .sZombieDuration > 0 Then .sZombieDuration -= 1

            If .sAgilityBreakDuration > 0 Then
                .sAgilityBreakDuration -= 1
                If .sAgilityBreakDuration = 0 Then
                    tEvasion += mEvasion * 0.5
                    tAccuracy += mAccuracy * 0.5
                End If
            End If

            If .sAgilityDownDuration > 0 Then
                .sAgilityDownDuration -= 1
                If .sAgilityDownDuration = 0 Then
                    tEvasion += mEvasion * 0.25
                    tAccuracy += mAccuracy * 0.25
                End If
            End If

            If .sArmorBreakDuration > 0 Then
                .sArmorBreakDuration -= 1
                If .sArmorBreakDuration = 0 Then
                    tArmor += mArmor * 0.5
                End If
            End If
            If .sArmorDownDuration > 0 Then
                .sArmorDownDuration -= 1
                If .sArmorDownDuration = 0 Then
                    tArmor += mArmor * 0.25
                End If
            End If

            If .sWeakElementIceDuration > 0 Then .sWeakElementIceDuration -= 1
            If .sWeakElementFireDuration > 0 Then .sWeakElementFireDuration -= 1
            If .sWeakElementLightningDuration > 0 Then .sWeakElementLightningDuration -= 1
            If .sWeakElementWindDuration > 0 Then .sWeakElementWindDuration -= 1
            If .sWeakElementWaterDuration > 0 Then .sWeakElementWaterDuration -= 1
            If .sWeakElementBioDuration > 0 Then .sWeakElementBioDuration -= 1
            If .sWeakElementShadowDuration > 0 Then .sWeakElementShadowDuration -= 1
            If .sWeakElementHolyDuration > 0 Then .sWeakElementHolyDuration -= 1

            If .sLockDuration > 0 Then
                .sLockDuration -= 1
                If .sLockDuration = 0 Then
                    tEvasion += 20
                    tMagicEvasion += 20
                End If
            End If

            If .sMagicBreakDuration > 0 Then .sMagicBreakDuration -= 1
            If .sMagicDownDuration > 0 Then .sMagicDownDuration -= 1

            If .sMeltdownDuration > 0 Then
                .sMeltdownDuration -= 1
                If .sMeltdownDuration = 0 Then
                    tArmor = mArmor
                    tMagicArmor = mMagicArmor
                End If
            End If

            If .sMentalBreakDuration > 0 Then
                .sMentalBreakDuration -= 1
                If .sMentalBreakDuration = 0 Then
                    tMagicArmor += mMagicArmor * 0.5
                End If
            End If

            If .sMentalDownDuration > 0 Then
                .sMentalDownDuration -= 1
                If .sMentalDownDuration Then
                    tMagicArmor += mMagicArmor * 0.25
                End If
            End If
            If .sPowerBreakDuration > 0 Then .sPowerBreakDuration -= 1
            If .sPowerDownDuration > 0 Then .sPowerDownDuration -= 1

            If .sSpiritBreakDuration > 0 Then
                .sSpiritBreakDuration -= 1
                If .sSpiritBreakDuration = 0 Then
                    tMagicAccuracy += mMagicAccuracy * 0.5
                    tMagicEvasion += mMagicEvasion * 0.5
                End If
            End If

            If .sSpiritDownDuration > 0 Then
                .sSpiritDownDuration -= 1
                If .sSpiritDownDuration = 0 Then
                    tMagicAccuracy += mMagicAccuracy * 0.25
                    tMagicEvasion += mMagicEvasion * 0.25
                End If
            End If

            If .sAbsorbElementIceDuration > 0 Then .sAbsorbElementIceDuration -= 1
            If .sAbsorbElementFireDuration > 0 Then .sAbsorbElementFireDuration -= 1
            If .sAbsorbElementLightningDuration > 0 Then .sAbsorbElementLightningDuration -= 1
            If .sAbsorbElementWaterDuration > 0 Then .sAbsorbElementWaterDuration -= 1
            If .sAbsorbElementWindDuration > 0 Then .sAbsorbElementWindDuration -= 1
            If .sAbsorbElementBioDuration > 0 Then .sAbsorbElementBioDuration -= 1
            If .sAbsorbElementShadowDuration > 0 Then .sAbsorbElementShadowDuration -= 1
            If .sAbsorbElementHolyDuration > 0 Then .sAbsorbElementHolyDuration -= 1
            If .sImmuneElementIceDuration > 0 Then .sImmuneElementIceDuration -= 1
            If .sImmuneElementFireDuration > 0 Then .sImmuneElementFireDuration -= 1
            If .sImmuneElementLightningDuration > 0 Then .sImmuneElementLightningDuration -= 1
            If .sImmuneElementWindDuration > 0 Then .sImmuneElementWindDuration -= 1
            If .sImmuneElementWaterDuration > 0 Then .sImmuneElementWaterDuration -= 1
            If .sImmuneElementBioDuration > 0 Then .sImmuneElementBioDuration -= 1
            If .sImmuneElementShadowDuration > 0 Then .sImmuneElementShadowDuration -= 1
            If .sImmuneElementHolyDuration > 0 Then .sImmuneElementHolyDuration -= 1
            If .sResistElementIceDuration > 0 Then .sResistElementIceDuration -= 1
            If .sResistElementFireDuration > 0 Then .sResistElementFireDuration -= 1
            If .sResistElementLightningDuration > 0 Then .sResistElementLightningDuration -= 1
            If .sResistElementWindDuration > 0 Then .sResistElementWindDuration -= 1
            If .sResistElementWaterDuration > 0 Then .sResistElementWaterDuration -= 1
            If .sResistElementBioDuration > 0 Then .sResistElementBioDuration -= 1
            If .sResistElementShadowDuration > 0 Then .sResistElementShadowDuration -= 1
            If .sResistElementHolyDuration > 0 Then .sResistElementHolyDuration -= 1
            If .sSpikesElementIceDuration > 0 Then .sSpikesElementIceDuration -= 1
            If .sSpikesElementFireDuration > 0 Then .sSpikesElementFireDuration -= 1
            If .sSpikesElementLightningDuration > 0 Then .sSpikesElementLightningDuration -= 1
            If .sSpikesElementWindDuration > 0 Then .sSpikesElementWindDuration -= 1
            If .sSpikesElementWaterDuration > 0 Then .sSpikesElementWaterDuration -= 1
            If .sSpikesElementBioDuration > 0 Then .sSpikesElementBioDuration -= 1
            If .sSpikesElementShadowDuration > 0 Then .sSpikesElementShadowDuration -= 1
            If .sSpikesElementHolyDuration > 0 Then .sSpikesElementHolyDuration -= 1
            If .sProtectDuration > 0 Then .sProtectDuration -= 1
            If .sReflectDuration > 0 Then .sReflectDuration -= 1
            If .sResistDuration > 0 Then .sResistDuration -= 1
            If .sShellDuration > 0 Then .sShellDuration -= 1
            If .sShieldDuration > 0 Then .sShieldDuration -= 1
            If .sWallDuration > 0 Then .sWallDuration -= 1

            If .sAccelerateDuration > 0 Then
                .sAccelerateDuration -= 1
                If .sAccelerateDuration = 0 Then
                    tSPD = mSPD
                End If
            End If

            If .sAccuracyUpDuration > 0 Then
                .sAccuracyUpDuration -= 1
                If .sAccuracyUpDuration = 0 Then
                    tAccuracy = mAccuracy
                End If
            End If

            If .sAgilityUpDuration > 0 Then
                .sAgilityUpDuration -= 1
                If .sAgilityUpDuration = 0 Then
                    tEvasion -= mEvasion * 0.25
                    tAccuracy -= mAccuracy * 0.25
                End If
            End If

            If .sArmorUpDuration > 0 Then
                .sArmorUpDuration -= 1
                If .sArmorUpDuration = 0 Then
                    tArmor -= mArmor * 0.25
                End If
            End If

            If .sAuraDuration > 0 Then .sAuraDuration -= 1

            If .sBlinkDuration > 0 Then
                .sBlinkDuration -= 1
                If .sBlinkDuration = 0 Then
                    tEvasion -= 20
                End If
            End If

            If .sCriticalUpDuration > 0 Then .sCriticalUpDuration -= 1
            If .sFlightDuration > 0 Then .sFlightDuration -= 1
            If .sFloatDuration > 0 Then .sFloatDuration -= 1
            If .sHasteDuration > 0 Then .sHasteDuration -= 1

            If .sMagicUpDuration > 0 Then .sMagicUpDuration -= 1

            If .sMentalUpDuration > 0 Then
                .sMentalUpDuration -= 1
                If .sMentalUpDuration = 0 Then
                    tMagicArmor -= mMagicArmor * 0.25
                End If
            End If

            If .sMPHalfDuration > 0 Then .sMPHalfDuration -= 1
            If .sMPQuarterDuration > 0 Then .sMPQuarterDuration -= 1
            If .sPowerUpDuration > 0 Then .sPowerUpDuration -= 1

            If .sRegenDuration > 0 Then
                If mHPCurrent + 0.1 * mHPMax >= mHPMax Then
                    mHPCurrent = mHPMax
                Else
                    mHPCurrent += 0.1 * mHPMax
                End If
                .sRegenDuration -= 1
            End If

            If .sReraiseDuration > 0 Then .sReraiseDuration -= 1

            If .sRuseDuration > 0 Then
                .sRuseDuration -= 1
                If .sRuseDuration = 0 Then
                    tEvasion -= 40
                End If
            End If

            If .sSpiritUpDuration > 0 Then
                .sSpiritUpDuration -= 1
                If .sSpiritUpDuration = 0 Then
                    tMagicEvasion -= mMagicEvasion * 0.25
                    tMagicAccuracy -= mMagicAccuracy * 0.25
                End If
            End If

            If .sVanishDuration > 0 Then .sVanishDuration -= 1
        End With
    End Sub

    Friend Sub RemoveStatus(ByVal Str As String)
        MonsterStatusEffects.RemoveStatus(Str)
    End Sub

    Friend Function GetStatusStr() As String()
        Return MonsterStatusEffects.GetStatusEffectStringArray()
    End Function
#End Region

#Region "MAGIC"
    Friend Function GetMagic()
        Return mMagic
    End Function
#End Region

#Region "TREASURE"
    Friend Function GetTreasure()
        Return mTreasureTable
    End Function
#End Region
End Class

