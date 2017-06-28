Public Class Magic
    Private _level As Integer
    Private _spellname As String
    Private _target As String
    Private _mpcost As Integer
    Private _cos As String
    Private _effect As String

    Public Sub New(ByVal Level As Integer, ByVal SpellName As String, ByVal Target As String, ByVal MPCost As Integer, ByVal COS As String, ByVal Effect As String)
        _level = Level
        _spellname = SpellName
        _target = Target
        _mpcost = MPCost
        _cos = COS
        _effect = Effect
    End Sub

    Public Property Level() As Integer
        Get
            Return _level
        End Get
        Set(value As Integer)
            _level = value
        End Set
    End Property

    Public Property SpellName() As String
        Get
            Return _spellname
        End Get
        Set(value As String)
            _spellname = value
        End Set
    End Property

    Public Property Target() As String
        Get
            Return _target
        End Get
        Set(value As String)
            _target = value
        End Set
    End Property

    Public Property MPCost() As Integer
        Get
            Return _mpcost
        End Get
        Set(value As Integer)
            _mpcost = value
        End Set
    End Property

    Public Property COS() As String
        Get
            Return _cos
        End Get
        Set(value As String)
            _cos = value
        End Set
    End Property

    Public Property Effect() As String
        Get
            Return _effect
        End Get
        Set(value As String)
            _effect = value
        End Set
    End Property
End Class
