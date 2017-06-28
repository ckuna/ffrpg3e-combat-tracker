Public Class StatusEffect
    'FATAL
    Friend sCondemnedDuration As Integer = 0
    Friend sDeathDuration As Integer = 0
    Friend sEjectDuration As Integer = 0
    Friend sFrozeDuration As Integer = 0
    Friend sHeatDuration As Integer = 0

    'MYSTIFY
    Friend sBerserkDuration As Integer = 0
    Friend sCharmDuration As Integer = 0
    Friend sConfuseDuration As Integer = 0
    Friend sUnawareDuration As Integer = 0

    'TOXIN
    Friend sPoisonDuration As Integer = 0
    Friend sVenomDuration As Integer = 0

    'SEAL
    Friend sBlindDuration As Integer = 0
    Friend sCurseDuration As Integer = 0
    Friend sPetrifyDuration As Integer = 0
    Friend sSilenceDuration As Integer = 0
    Friend sSleepDuration As Integer = 0
    Friend sStoneDuration As Integer = 0

    'TIME
    Friend sDisableDuration As Integer = 0
    Friend sImmobilizeDuration As Integer = 0
    Friend sSapDuration As Integer = 0
    Friend sSlowDuration As Integer = 0
    Friend sStopDuration As Integer = 0

    'TRANSFORM
    Friend sMiniDuration As Integer = 0
    Friend sToadDuration As Integer = 0
    Friend sZombieDuration As Integer = 0

    'WEAKEN
    Friend sAgilityBreakDuration As Integer = 0
    Friend sAgilityDownDuration As Integer = 0
    Friend sArmorBreakDuration As Integer = 0
    Friend sArmorDownDuration As Integer = 0
    Friend sWeakElementIceDuration As Integer = 0
    Friend sWeakElementFireDuration As Integer = 0
    Friend sWeakElementLightningDuration As Integer = 0
    Friend sWeakElementWindDuration As Integer = 0
    Friend sWeakElementWaterDuration As Integer = 0
    Friend sWeakElementBioDuration As Integer = 0
    Friend sWeakElementShadowDuration As Integer = 0
    Friend sWeakElementHolyDuration As Integer = 0
    Friend sLockDuration As Integer = 0
    Friend sMagicBreakDuration As Integer = 0
    Friend sMagicDownDuration As Integer = 0
    Friend sMeltdownDuration As Integer = 0
    Friend sMentalBreakDuration As Integer = 0
    Friend sMentalDownDuration As Integer = 0
    Friend sPowerBreakDuration As Integer = 0
    Friend sPowerDownDuration As Integer = 0
    Friend sSpiritBreakDuration As Integer = 0
    Friend sSpiritDownDuration As Integer = 0

    'BARRIER
    Friend sAbsorbElementIceDuration As Integer = 0
    Friend sAbsorbElementFireDuration As Integer = 0
    Friend sAbsorbElementLightningDuration As Integer = 0
    Friend sAbsorbElementWaterDuration As Integer = 0
    Friend sAbsorbElementWindDuration As Integer = 0
    Friend sAbsorbElementBioDuration As Integer = 0
    Friend sAbsorbElementShadowDuration As Integer = 0
    Friend sAbsorbElementHolyDuration As Integer = 0
    Friend sImmuneElementIceDuration As Integer = 0
    Friend sImmuneElementFireDuration As Integer = 0
    Friend sImmuneElementLightningDuration As Integer = 0
    Friend sImmuneElementWindDuration As Integer = 0
    Friend sImmuneElementWaterDuration As Integer = 0
    Friend sImmuneElementBioDuration As Integer = 0
    Friend sImmuneElementShadowDuration As Integer = 0
    Friend sImmuneElementHolyDuration As Integer = 0
    Friend sResistElementIceDuration As Integer = 0
    Friend sResistElementFireDuration As Integer = 0
    Friend sResistElementLightningDuration As Integer = 0
    Friend sResistElementWindDuration As Integer = 0
    Friend sResistElementWaterDuration As Integer = 0
    Friend sResistElementBioDuration As Integer = 0
    Friend sResistElementShadowDuration As Integer = 0
    Friend sResistElementHolyDuration As Integer = 0
    Friend sSpikesElementIceDuration As Integer = 0
    Friend sSpikesElementFireDuration As Integer = 0
    Friend sSpikesElementLightningDuration As Integer = 0
    Friend sSpikesElementWindDuration As Integer = 0
    Friend sSpikesElementWaterDuration As Integer = 0
    Friend sSpikesElementBioDuration As Integer = 0
    Friend sSpikesElementShadowDuration As Integer = 0
    Friend sSpikesElementHolyDuration As Integer = 0
    Friend sProtectDuration As Integer = 0
    Friend sReflectDuration As Integer = 0
    Friend sResistDuration As Integer = 0
    Friend sShellDuration As Integer = 0
    Friend sShieldDuration As Integer = 0
    Friend sWallDuration As Integer = 0

    'STRENGTHEN
    Friend sAccelerateDuration As Integer = 0
    Friend sAccuracyUpDuration As Integer = 0
    Friend sAgilityUpDuration As Integer = 0
    Friend sArmorUpDuration As Integer = 0
    Friend sAuraDuration As Integer = 0
    Friend sBlinkDuration As Integer = 0
    Friend sCriticalUpDuration As Integer = 0
    Friend sFlightDuration As Integer = 0
    Friend sFloatDuration As Integer = 0
    Friend sHasteDuration As Integer = 0
    Friend sMagicUpDuration As Integer = 0
    Friend sMentalUpDuration As Integer = 0
    Friend sMPHalfDuration As Integer = 0
    Friend sMPQuarterDuration As Integer = 0
    Friend sPowerUpDuration As Integer = 0
    Friend sRegenDuration As Integer = 0
    Friend sReraiseDuration As Integer = 0
    Friend sRuseDuration As Integer = 0
    Friend sSpiritUpDuration As Integer = 0
    Friend sVanishDuration As Integer = 0

    Friend Sub RemoveStatus(ByVal Str As String)
        Dim eStr As String = Mid(Str, 1, Str.IndexOf("("))

        Select Case eStr
            Case "Condemned" : sCondemnedDuration = 0
            Case "Death" : sDeathDuration = 0
            Case "Eject" : sEjectDuration = 0
            Case "Froze" : sFrozeDuration = 0
            Case "Heat" : sHeatDuration = 0
            Case "Berserk" : sBerserkDuration = 0
            Case "Charm" : sCharmDuration = 0
            Case "Confuse" : sConfuseDuration = 0
            Case "Unaware" : sUnawareDuration = 0
            Case "Poison" : sPoisonDuration = 0
            Case "Venom" : sVenomDuration = 0
            Case "Blind" : sBlindDuration = 0
            Case "Curse" : sCurseDuration = 0
            Case "Petrify" : sPetrifyDuration = 0
            Case "Silence" : sSilenceDuration = 0
            Case "Sleep" : sSleepDuration = 0
            Case "Stone" : sStoneDuration = 0
            Case "Disable" : sDisableDuration = 0
            Case "Immobilize" : sImmobilizeDuration = 0
            Case "Sap" : sSapDuration = 0
            Case "Slow" : sSlowDuration = 0
            Case "Stop" : sStopDuration = 0
            Case "Mini" : sMiniDuration = 0
            Case "Toad" : sToadDuration = 0
            Case "Zombie" : sZombieDuration = 0
            Case "AgilityBreak" : sAgilityBreakDuration = 0
            Case "AgilityDown" : sAgilityDownDuration = 0
            Case "ArmorBreak" : sArmorBreakDuration = 0
            Case "ArmorDown" : sArmorDownDuration = 0
            Case "WeakElementIce" : sWeakElementIceDuration = 0
            Case "WeakElementFire" : sWeakElementFireDuration = 0
            Case "WeakElementLightning" : sWeakElementLightningDuration = 0
            Case "WeakElementWind" : sWeakElementWindDuration = 0
            Case "WeakElementWater" : sWeakElementWaterDuration = 0
            Case "WeakElementBio" : sWeakElementBioDuration = 0
            Case "WeakElementShadow" : sWeakElementShadowDuration = 0
            Case "WeakElementHoly" : sWeakElementHolyDuration = 0
            Case "Lock" : sLockDuration = 0
            Case "MagicBreak" : sMagicBreakDuration = 0
            Case "MagicDown" : sMagicDownDuration = 0
            Case "Meltdown" : sMeltdownDuration = 0
            Case "MentalBreak" : sMentalBreakDuration = 0
            Case "MentalDown" : sMentalDownDuration = 0
            Case "PowerBreak" : sPowerBreakDuration = 0
            Case "PowerDown" : sPowerDownDuration = 0
            Case "SpiritBreak" : sSpiritBreakDuration = 0
            Case "SpiritDown" : sSpiritDownDuration = 0
            Case "AbsorbElementIce" : sAbsorbElementIceDuration = 0
            Case "AbsorbElementFire" : sAbsorbElementFireDuration = 0
            Case "AbsorbElementLightning" : sAbsorbElementLightningDuration = 0
            Case "AbsorbElementWater" : sAbsorbElementWaterDuration = 0
            Case "AbsorbElementWind" : sAbsorbElementWindDuration = 0
            Case "AbsorbElementBio" : sAbsorbElementBioDuration = 0
            Case "AbsorbElementShadow" : sAbsorbElementShadowDuration = 0
            Case "AbsorbElementHoly" : sAbsorbElementHolyDuration = 0
            Case "ImmuneElementIce" : sImmuneElementIceDuration = 0
            Case "ImmuneElementFire" : sImmuneElementFireDuration = 0
            Case "ImmuneElementLightning" : sImmuneElementLightningDuration = 0
            Case "ImmuneElementWind" : sImmuneElementWindDuration = 0
            Case "ImmuneElementWater" : sImmuneElementWaterDuration = 0
            Case "ImmuneElementBio" : sImmuneElementBioDuration = 0
            Case "ImmuneElementShadow" : sImmuneElementShadowDuration = 0
            Case "ImmuneElementHoly" : sImmuneElementHolyDuration = 0
            Case "ResistElementIce" : sResistElementIceDuration = 0
            Case "ResistElementFire" : sResistElementFireDuration = 0
            Case "ResistElementLightning" : sResistElementLightningDuration = 0
            Case "ResistElementWind" : sResistElementWindDuration = 0
            Case "ResistElementWater" : sResistElementWaterDuration = 0
            Case "ResistElementBio" : sResistElementBioDuration = 0
            Case "ResistElementShadow" : sResistElementShadowDuration = 0
            Case "ResistElementHoly" : sResistElementHolyDuration = 0
            Case "SpikesElementIce" : sSpikesElementIceDuration = 0
            Case "SpikesElementFire" : sSpikesElementFireDuration = 0
            Case "SpikesElementLightning" : sSpikesElementLightningDuration = 0
            Case "SpikesElementWind" : sSpikesElementWindDuration = 0
            Case "SpikesElementWater" : sSpikesElementWaterDuration = 0
            Case "SpikesElementBio" : sSpikesElementBioDuration = 0
            Case "SpikesElementShadow" : sSpikesElementShadowDuration = 0
            Case "SpikesElementHoly" : sSpikesElementHolyDuration = 0
            Case "Protect" : sProtectDuration = 0
            Case "Reflect" : sReflectDuration = 0
            Case "Resist" : sResistDuration = 0
            Case "Shell" : sShellDuration = 0
            Case "Shield" : sShieldDuration = 0
            Case "Wall" : sWallDuration = 0
            Case "Accelerate" : sAccelerateDuration = 0
            Case "AccuracyUp" : sAccuracyUpDuration = 0
            Case "AgilityUp" : sAgilityUpDuration = 0
            Case "ArmorUp" : sArmorUpDuration = 0
            Case "Aura" : sAuraDuration = 0
            Case "Blink" : sBlinkDuration = 0
            Case "CriticalUp" : sCriticalUpDuration = 0
            Case "Flight" : sFlightDuration = 0
            Case "Float" : sFloatDuration = 0
            Case "Haste" : sHasteDuration = 0
            Case "MagicUp" : sMagicUpDuration = 0
            Case "MentalUp" : sMentalUpDuration = 0
            Case "MPHalf" : sMPHalfDuration = 0
            Case "MPQuarter" : sMPQuarterDuration = 0
            Case "PowerUp" : sPowerUpDuration = 0
            Case "Regen" : sRegenDuration = 0
            Case "Reraise" : sReraiseDuration = 0
            Case "Ruse" : sRuseDuration = 0
            Case "SpiritUp" : sSpiritUpDuration = 0
            Case "Vanish" : sVanishDuration = 0
        End Select
    End Sub

    Friend Sub AddStatus(ByVal Status As String, ByVal Duration As Integer)
        Select Case Status
            Case "Condemned" : sCondemnedDuration = Duration
            Case "Death" : sDeathDuration = Duration
            Case "Eject" : sEjectDuration = Duration
            Case "Froze" : sFrozeDuration = Duration
            Case "Heat" : sHeatDuration = Duration
            Case "Berserk" : sBerserkDuration = Duration
            Case "Charm" : sCharmDuration = Duration
            Case "Confuse" : sConfuseDuration = Duration
            Case "Unaware" : sUnawareDuration = Duration
            Case "Poison" : sPoisonDuration = Duration
            Case "Venom" : sVenomDuration = Duration
            Case "Blind" : sBlindDuration = Duration
            Case "Curse" : sCurseDuration = Duration
            Case "Petrify" : sPetrifyDuration = Duration
            Case "Silence" : sSilenceDuration = Duration
            Case "Sleep" : sSleepDuration = Duration
            Case "Stone" : sStoneDuration = Duration
            Case "Disable" : sDisableDuration = Duration
            Case "Immobilize" : sImmobilizeDuration = Duration
            Case "Sap" : sSapDuration = Duration
            Case "Slow" : sSlowDuration = Duration
            Case "Stop" : sStopDuration = Duration
            Case "Mini" : sMiniDuration = Duration
            Case "Toad" : sToadDuration = Duration
            Case "Zombie" : sZombieDuration = Duration
            Case "AgilityBreak" : sAgilityBreakDuration = Duration
            Case "AgilityDown" : sAgilityDownDuration = Duration
            Case "ArmorBreak" : sArmorBreakDuration = Duration
            Case "ArmorDown" : sArmorDownDuration = Duration
            Case "WeakElementIce" : sWeakElementIceDuration = Duration
            Case "WeakElementFire" : sWeakElementFireDuration = Duration
            Case "WeakElementLightning" : sWeakElementLightningDuration = Duration
            Case "WeakElementWind" : sWeakElementWindDuration = Duration
            Case "WeakElementWater" : sWeakElementWaterDuration = Duration
            Case "WeakElementBio" : sWeakElementBioDuration = Duration
            Case "WeakElementShadow" : sWeakElementShadowDuration = Duration
            Case "WeakElementHoly" : sWeakElementHolyDuration = Duration
            Case "Lock" : sLockDuration = Duration
            Case "MagicBreak" : sMagicBreakDuration = Duration
            Case "MagicDown" : sMagicDownDuration = Duration
            Case "Meltdown" : sMeltdownDuration = Duration
            Case "MentalBreak" : sMentalBreakDuration = Duration
            Case "MentalDown" : sMentalDownDuration = Duration
            Case "PowerBreak" : sPowerBreakDuration = Duration
            Case "PowerDown" : sPowerDownDuration = Duration
            Case "SpiritBreak" : sSpiritBreakDuration = Duration
            Case "SpiritDown" : sSpiritDownDuration = Duration
            Case "AbsorbElementIce" : sAbsorbElementIceDuration = Duration
            Case "AbsorbElementFire" : sAbsorbElementFireDuration = Duration
            Case "AbsorbElementLightning" : sAbsorbElementLightningDuration = Duration
            Case "AbsorbElementWater" : sAbsorbElementWaterDuration = Duration
            Case "AbsorbElementWind" : sAbsorbElementWindDuration = Duration
            Case "AbsorbElementBio" : sAbsorbElementBioDuration = Duration
            Case "AbsorbElementShadow" : sAbsorbElementShadowDuration = Duration
            Case "AbsorbElementHoly" : sAbsorbElementHolyDuration = Duration
            Case "ImmuneElementIce" : sImmuneElementIceDuration = Duration
            Case "ImmuneElementFire" : sImmuneElementFireDuration = Duration
            Case "ImmuneElementLightning" : sImmuneElementLightningDuration = Duration
            Case "ImmuneElementWind" : sImmuneElementWindDuration = Duration
            Case "ImmuneElementWater" : sImmuneElementWaterDuration = Duration
            Case "ImmuneElementBio" : sImmuneElementBioDuration = Duration
            Case "ImmuneElementShadow" : sImmuneElementShadowDuration = Duration
            Case "ImmuneElementHoly" : sImmuneElementHolyDuration = Duration
            Case "ResistElementIce" : sResistElementIceDuration = Duration
            Case "ResistElementFire" : sResistElementFireDuration = Duration
            Case "ResistElementLightning" : sResistElementLightningDuration = Duration
            Case "ResistElementWind" : sResistElementWindDuration = Duration
            Case "ResistElementWater" : sResistElementWaterDuration = Duration
            Case "ResistElementBio" : sResistElementBioDuration = Duration
            Case "ResistElementShadow" : sResistElementShadowDuration = Duration
            Case "ResistElementHoly" : sResistElementHolyDuration = Duration
            Case "SpikesElementIce" : sSpikesElementIceDuration = Duration
            Case "SpikesElementFire" : sSpikesElementFireDuration = Duration
            Case "SpikesElementLightning" : sSpikesElementLightningDuration = Duration
            Case "SpikesElementWind" : sSpikesElementWindDuration = Duration
            Case "SpikesElementWater" : sSpikesElementWaterDuration = Duration
            Case "SpikesElementBio" : sSpikesElementBioDuration = Duration
            Case "SpikesElementShadow" : sSpikesElementShadowDuration = Duration
            Case "SpikesElementHoly" : sSpikesElementHolyDuration = Duration
            Case "Protect" : sProtectDuration = Duration
            Case "Reflect" : sReflectDuration = Duration
            Case "Resist" : sResistDuration = Duration
            Case "Shell" : sShellDuration = Duration
            Case "Shield" : sShieldDuration = Duration
            Case "Wall" : sWallDuration = Duration
            Case "Accelerate" : sAccelerateDuration = Duration
            Case "AccuracyUp" : sAccuracyUpDuration = Duration
            Case "AgilityUp" : sAgilityUpDuration = Duration
            Case "ArmorUp" : sArmorUpDuration = Duration
            Case "Aura" : sAuraDuration = Duration
            Case "Blink" : sBlinkDuration = Duration
            Case "CriticalUp" : sCriticalUpDuration = Duration
            Case "Flight" : sFlightDuration = Duration
            Case "Float" : sFloatDuration = Duration
            Case "Haste" : sHasteDuration = Duration
            Case "MagicUp" : sMagicUpDuration = Duration
            Case "MentalUp" : sMentalUpDuration = Duration
            Case "MPHalf" : sMPHalfDuration = Duration
            Case "MPQuarter" : sMPQuarterDuration = Duration
            Case "PowerUp" : sPowerUpDuration = Duration
            Case "Regen" : sRegenDuration = Duration
            Case "Reraise" : sReraiseDuration = Duration
            Case "Ruse" : sRuseDuration = Duration
            Case "SpiritUp" : sSpiritUpDuration = Duration
            Case "Vanish" : sVanishDuration = Duration
        End Select
    End Sub

    Friend Function GetStatusEffectStringArray() As String()
        Dim Str() As String

        If sCondemnedDuration > 0 Then ResizeAndAddString(Str, "Condemned(" & sCondemnedDuration & ")")
        If sDeathDuration > 0 Then ResizeAndAddString(Str, "Death(" & sDeathDuration & ")")
        If sEjectDuration > 0 Then ResizeAndAddString(Str, "Eject(" & sEjectDuration & ")")
        If sFrozeDuration > 0 Then ResizeAndAddString(Str, "Froze(" & sFrozeDuration & ")")
        If sHeatDuration > 0 Then ResizeAndAddString(Str, "Heat(" & sHeatDuration & ")")
        If sBerserkDuration > 0 Then ResizeAndAddString(Str, "Berserk(" & sBerserkDuration & ")")
        If sCharmDuration > 0 Then ResizeAndAddString(Str, "Charm(" & sCharmDuration & ")")
        If sConfuseDuration > 0 Then ResizeAndAddString(Str, "Confuse(" & sConfuseDuration & ")")
        If sUnawareDuration > 0 Then ResizeAndAddString(Str, "Unaware(" & sUnawareDuration & ")")
        If sPoisonDuration > 0 Then ResizeAndAddString(Str, "Poison(" & sPoisonDuration & ")")
        If sVenomDuration > 0 Then ResizeAndAddString(Str, "Venom(" & sVenomDuration & ")")
        If sBlindDuration > 0 Then ResizeAndAddString(Str, "Blind(" & sBlindDuration & ")")
        If sCurseDuration > 0 Then ResizeAndAddString(Str, "Curse(" & sCurseDuration & ")")
        If sPetrifyDuration > 0 Then ResizeAndAddString(Str, "Petrify(" & sPetrifyDuration & ")")
        If sSilenceDuration > 0 Then ResizeAndAddString(Str, "Silence(" & sSilenceDuration & ")")
        If sSleepDuration > 0 Then ResizeAndAddString(Str, "Sleep(" & sSleepDuration & ")")
        If sStoneDuration > 0 Then ResizeAndAddString(Str, "Stone(" & sStoneDuration & ")")
        If sDisableDuration > 0 Then ResizeAndAddString(Str, "Disable(" & sDisableDuration & ")")
        If sImmobilizeDuration > 0 Then ResizeAndAddString(Str, "Immobilize(" & sImmobilizeDuration & ")")
        If sSapDuration > 0 Then ResizeAndAddString(Str, "Sap(" & sSapDuration & ")")
        If sSlowDuration > 0 Then ResizeAndAddString(Str, "Slow(" & sSlowDuration & ")")
        If sStopDuration > 0 Then ResizeAndAddString(Str, "Stop(" & sStopDuration & ")")
        If sMiniDuration > 0 Then ResizeAndAddString(Str, "Mini(" & sMiniDuration & ")")
        If sToadDuration > 0 Then ResizeAndAddString(Str, "Toad(" & sToadDuration & ")")
        If sZombieDuration > 0 Then ResizeAndAddString(Str, "Zombie(" & sZombieDuration & ")")
        If sAgilityBreakDuration > 0 Then ResizeAndAddString(Str, "AgilityBreak(" & sAgilityBreakDuration & ")")
        If sAgilityDownDuration > 0 Then ResizeAndAddString(Str, "AgilityDown(" & sAgilityDownDuration & ")")
        If sArmorBreakDuration > 0 Then ResizeAndAddString(Str, "ArmorBreak(" & sArmorBreakDuration & ")")
        If sArmorDownDuration > 0 Then ResizeAndAddString(Str, "ArmorDown(" & sArmorDownDuration & ")")
        If sWeakElementIceDuration > 0 Then ResizeAndAddString(Str, "WeakElementIce(" & sWeakElementIceDuration & ")")
        If sWeakElementFireDuration > 0 Then ResizeAndAddString(Str, "WeakElementFire(" & sWeakElementFireDuration & ")")
        If sWeakElementLightningDuration > 0 Then ResizeAndAddString(Str, "WeakElementLightning(" & sWeakElementLightningDuration & ")")
        If sWeakElementWindDuration > 0 Then ResizeAndAddString(Str, "WeakElementWind(" & sWeakElementWindDuration & ")")
        If sWeakElementWaterDuration > 0 Then ResizeAndAddString(Str, "WeakElementWater(" & sWeakElementWaterDuration & ")")
        If sWeakElementBioDuration > 0 Then ResizeAndAddString(Str, "WeakElementBio(" & sWeakElementBioDuration & ")")
        If sWeakElementShadowDuration > 0 Then ResizeAndAddString(Str, "WeakElementShadow(" & sWeakElementShadowDuration & ")")
        If sWeakElementHolyDuration > 0 Then ResizeAndAddString(Str, "WeakElementHoly(" & sWeakElementHolyDuration & ")")
        If sLockDuration > 0 Then ResizeAndAddString(Str, "Lock(" & sLockDuration & ")")
        If sMagicBreakDuration > 0 Then ResizeAndAddString(Str, "MagicBreak(" & sMagicBreakDuration & ")")
        If sMagicDownDuration > 0 Then ResizeAndAddString(Str, "MagicDown(" & sMagicDownDuration & ")")
        If sMeltdownDuration > 0 Then ResizeAndAddString(Str, "Meltdown(" & sMeltdownDuration & ")")
        If sMentalBreakDuration > 0 Then ResizeAndAddString(Str, "MentalBreak(" & sMentalBreakDuration & ")")
        If sMentalDownDuration > 0 Then ResizeAndAddString(Str, "MentalDown(" & sMentalDownDuration & ")")
        If sPowerBreakDuration > 0 Then ResizeAndAddString(Str, "PowerBreak(" & sPowerBreakDuration & ")")
        If sPowerDownDuration > 0 Then ResizeAndAddString(Str, "PowerDown(" & sPowerDownDuration & ")")
        If sSpiritBreakDuration > 0 Then ResizeAndAddString(Str, "SpiritBreak(" & sSpiritBreakDuration & ")")
        If sSpiritDownDuration > 0 Then ResizeAndAddString(Str, "SpiritDown(" & sSpiritDownDuration & ")")
        If sAbsorbElementIceDuration > 0 Then ResizeAndAddString(Str, "AbsorbElementIce(" & sAbsorbElementIceDuration & ")")
        If sAbsorbElementFireDuration > 0 Then ResizeAndAddString(Str, "AbsorbElementFire(" & sAbsorbElementFireDuration & ")")
        If sAbsorbElementLightningDuration > 0 Then ResizeAndAddString(Str, "AbsorbElementLightning(" & sAbsorbElementLightningDuration & ")")
        If sAbsorbElementWaterDuration > 0 Then ResizeAndAddString(Str, "AbsorbElementWater(" & sAbsorbElementWaterDuration & ")")
        If sAbsorbElementWindDuration > 0 Then ResizeAndAddString(Str, "AbsorbElementWind(" & sAbsorbElementWindDuration & ")")
        If sAbsorbElementBioDuration > 0 Then ResizeAndAddString(Str, "AbsorbElementBio(" & sAbsorbElementBioDuration & ")")
        If sAbsorbElementShadowDuration > 0 Then ResizeAndAddString(Str, "AbsorbElementShadow(" & sAbsorbElementShadowDuration & ")")
        If sAbsorbElementHolyDuration > 0 Then ResizeAndAddString(Str, "AbsorbElementHoly(" & sAbsorbElementHolyDuration & ")")
        If sImmuneElementIceDuration > 0 Then ResizeAndAddString(Str, "ImmuneElementIce(" & sImmuneElementIceDuration & ")")
        If sImmuneElementFireDuration > 0 Then ResizeAndAddString(Str, "ImmuneElementFire(" & sImmuneElementFireDuration & ")")
        If sImmuneElementLightningDuration > 0 Then ResizeAndAddString(Str, "ImmuneElementLightning(" & sImmuneElementLightningDuration & ")")
        If sImmuneElementWindDuration > 0 Then ResizeAndAddString(Str, "ImmuneElementWind(" & sImmuneElementWindDuration & ")")
        If sImmuneElementWaterDuration > 0 Then ResizeAndAddString(Str, "ImmuneElementWater(" & sImmuneElementWaterDuration & ")")
        If sImmuneElementBioDuration > 0 Then ResizeAndAddString(Str, "ImmuneElementBio(" & sImmuneElementBioDuration & ")")
        If sImmuneElementShadowDuration > 0 Then ResizeAndAddString(Str, "ImmuneElementShadow(" & sImmuneElementShadowDuration & ")")
        If sImmuneElementHolyDuration > 0 Then ResizeAndAddString(Str, "ImmuneElementHoly(" & sImmuneElementHolyDuration & ")")
        If sResistElementIceDuration > 0 Then ResizeAndAddString(Str, "ResistElementIce(" & sResistElementIceDuration & ")")
        If sResistElementFireDuration > 0 Then ResizeAndAddString(Str, "ResistElementFire(" & sResistElementFireDuration & ")")
        If sResistElementLightningDuration > 0 Then ResizeAndAddString(Str, "ResistElementLightning(" & sResistElementLightningDuration & ")")
        If sResistElementWindDuration > 0 Then ResizeAndAddString(Str, "ResistElementWind(" & sResistElementWindDuration & ")")
        If sResistElementWaterDuration > 0 Then ResizeAndAddString(Str, "ResistElementWater(" & sResistElementWaterDuration & ")")
        If sResistElementBioDuration > 0 Then ResizeAndAddString(Str, "ResistElementBio(" & sResistElementBioDuration & ")")
        If sResistElementShadowDuration > 0 Then ResizeAndAddString(Str, "ResistElementShadow(" & sResistElementShadowDuration & ")")
        If sResistElementHolyDuration > 0 Then ResizeAndAddString(Str, "ResistElementHoly(" & sResistElementHolyDuration & ")")
        If sSpikesElementIceDuration > 0 Then ResizeAndAddString(Str, "SpikesElementIce(" & sSpikesElementIceDuration & ")")
        If sSpikesElementFireDuration > 0 Then ResizeAndAddString(Str, "SpikesElementFire(" & sSpikesElementFireDuration & ")")
        If sSpikesElementLightningDuration > 0 Then ResizeAndAddString(Str, "SpikesElementLightning(" & sSpikesElementLightningDuration & ")")
        If sSpikesElementWindDuration > 0 Then ResizeAndAddString(Str, "SpikesElementWind(" & sSpikesElementWindDuration & ")")
        If sSpikesElementWaterDuration > 0 Then ResizeAndAddString(Str, "SpikesElementWater(" & sSpikesElementWaterDuration & ")")
        If sSpikesElementBioDuration > 0 Then ResizeAndAddString(Str, "SpikesElementBio(" & sSpikesElementBioDuration & ")")
        If sSpikesElementShadowDuration > 0 Then ResizeAndAddString(Str, "SpikesElementShadow(" & sSpikesElementShadowDuration & ")")
        If sSpikesElementHolyDuration > 0 Then ResizeAndAddString(Str, "SpikesElementHoly(" & sSpikesElementHolyDuration & ")")
        If sProtectDuration > 0 Then ResizeAndAddString(Str, "Protect(" & sProtectDuration & ")")
        If sReflectDuration > 0 Then ResizeAndAddString(Str, "Reflect(" & sReflectDuration & ")")
        If sResistDuration > 0 Then ResizeAndAddString(Str, "Resist(" & sResistDuration & ")")
        If sShellDuration > 0 Then ResizeAndAddString(Str, "Shell(" & sShellDuration & ")")
        If sShieldDuration > 0 Then ResizeAndAddString(Str, "Shield(" & sShieldDuration & ")")
        If sWallDuration > 0 Then ResizeAndAddString(Str, "Wall(" & sWallDuration & ")")
        If sAccelerateDuration > 0 Then ResizeAndAddString(Str, "Accelerate(" & sAccelerateDuration & ")")
        If sAccuracyUpDuration > 0 Then ResizeAndAddString(Str, "AccuracyUp(" & sAccuracyUpDuration & ")")
        If sAgilityUpDuration > 0 Then ResizeAndAddString(Str, "AgilityUp(" & sAgilityUpDuration & ")")
        If sArmorUpDuration > 0 Then ResizeAndAddString(Str, "ArmorUp(" & sArmorUpDuration & ")")
        If sAuraDuration > 0 Then ResizeAndAddString(Str, "Aura(" & sAuraDuration & ")")
        If sBlinkDuration > 0 Then ResizeAndAddString(Str, "Blink(" & sBlinkDuration & ")")
        If sCriticalUpDuration > 0 Then ResizeAndAddString(Str, "CriticalUp(" & sCriticalUpDuration & ")")
        If sFlightDuration > 0 Then ResizeAndAddString(Str, "Flight(" & sFlightDuration & ")")
        If sFloatDuration > 0 Then ResizeAndAddString(Str, "Float(" & sFloatDuration & ")")
        If sHasteDuration > 0 Then ResizeAndAddString(Str, "Haste(" & sHasteDuration & ")")
        If sMagicUpDuration > 0 Then ResizeAndAddString(Str, "MagicUp(" & sMagicUpDuration & ")")
        If sMentalUpDuration > 0 Then ResizeAndAddString(Str, "MentalUp(" & sMentalUpDuration & ")")
        If sMPHalfDuration > 0 Then ResizeAndAddString(Str, "MPHalf(" & sMPHalfDuration & ")")
        If sMPQuarterDuration > 0 Then ResizeAndAddString(Str, "MPQuarter(" & sMPQuarterDuration & ")")
        If sPowerUpDuration > 0 Then ResizeAndAddString(Str, "PowerUp(" & sPowerUpDuration & ")")
        If sRegenDuration > 0 Then ResizeAndAddString(Str, "Regen(" & sRegenDuration & ")")
        If sReraiseDuration > 0 Then ResizeAndAddString(Str, "Reraise(" & sReraiseDuration & ")")
        If sRuseDuration > 0 Then ResizeAndAddString(Str, "Ruse(" & sRuseDuration & ")")
        If sSpiritUpDuration > 0 Then ResizeAndAddString(Str, "SpiritUp(" & sSpiritUpDuration & ")")
        If sVanishDuration > 0 Then ResizeAndAddString(Str, "Vanish(" & sVanishDuration & ")")

        Return Str
    End Function

    Private Sub ResizeAndAddString(ByRef Str As String(), ByVal Text As String)
        If Str IsNot Nothing Then
            ReDim Preserve Str(UBound(Str) + 1)
            Str(UBound(Str)) = Text
        Else
            ReDim Str(0)
            Str(0) = Text
        End If
    End Sub
End Class

