Public Class DroppedItem
    Private _Name As String
    Private _Cost As Integer
    Private _Availability As Integer
    Private _Effect As String
    Private _Roll As String

    Public Sub New()
        _Name = ""
        _Cost = 0
        _Availability = 0
        _Effect = 0
    End Sub
    Public Sub New(ByVal Name As String, ByVal Cost As Integer, ByVal Availability As Integer, ByVal Effect As String)
        _Name = Name
        _Cost = Cost
        _Availability = Availability
        _Effect = Effect
    End Sub
    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(value As String)
            _Name = value
        End Set
    End Property
    Public Property Cost() As Integer
        Get
            Return _Cost
        End Get
        Set(value As Integer)
            _Cost = value
        End Set
    End Property
    Public Property Availability() As Integer
        Get
            Return _Availability
        End Get
        Set(value As Integer)
            _Availability = value
        End Set
    End Property
    Public Property Effect() As String
        Get
            Return _Effect
        End Get
        Set(value As String)
            _Effect = value
        End Set
    End Property
    Public Property Roll() As String
        Get
            Return _Roll
        End Get
        Set(value As String)
            _Roll = value
        End Set
    End Property
End Class
