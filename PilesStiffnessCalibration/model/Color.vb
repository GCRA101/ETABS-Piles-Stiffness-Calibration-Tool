Public Class Color
    Implements ColorInterface

    ' ATTRIBUTES
    Private red As Byte
    Private green As Byte
    Private blue As Byte
    Private RGB As Byte()
    Private etabsIntValue As Integer

    ' CONSTRUCTOR
    Public Sub New(red As Byte, green As Byte, blue As Byte)
        Me.red = red
        Me.green = green
        Me.blue = blue

        Me.RGB = New Byte() {red, green, blue}
        Me.etabsIntValue = Me.getEtabsIntValue()
    End Sub

    ' METHODS (Interface Implementation)
    Public Function getRed() As Byte Implements ColorInterface.getRed
        Return Me.red
    End Function

    Public Function getGreen() As Byte Implements ColorInterface.getGreen
        Return Me.green
    End Function

    Public Function getBlue() As Byte Implements ColorInterface.getBlue
        Return Me.blue
    End Function

    Public Function getRGB() As Byte() Implements ColorInterface.getRGB
        Return Me.RGB
    End Function

    Public Function getEtabsIntValue() As Integer Implements ColorInterface.getEtabsIntValue
        Return CInt(Me.getRed()) +
               CInt(Me.getGreen()) * 256 +
               CInt(Me.getBlue()) * 256 * 256
    End Function

End Class