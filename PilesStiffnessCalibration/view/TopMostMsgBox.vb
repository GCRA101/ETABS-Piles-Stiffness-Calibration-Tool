Imports System.Drawing
Imports System.Windows.Forms


''' <summary>
''' Concrete class providing a top‑most message box utility for displaying modal warnings and 
''' notifications that must appear above all other windows, including external applications.
''' </summary>
''' 
''' <remarks>
''' <para>
''' This concrete class encapsulates the logic required to display a MessageBox with a 
''' temporary top‑most owner window. The owner window is created off‑screen and ensures 
''' that the dialog is rendered in the foreground regardless of the current z‑order of 
''' other application windows.
''' </para>
''' 
''' <para>
''' Design Patterns:
''' - FACADE: The class exposes a simplified interface for creating top‑most dialogs 
'''   while hiding the underlying window‑management details.
''' </para>
''' 
''' </remarks>


Public NotInheritable Class TopMostMsgBox

    ' CONSTRUCTOR
    Private Sub New()
    End Sub

    ' METHODS
    Public Shared Function Show(text As String,
                                Optional caption As String = "",
                                Optional buttons As MessageBoxButtons = MessageBoxButtons.OK,
                                Optional icon As MessageBoxIcon = MessageBoxIcon.None) As DialogResult

        ' Create invisible top-most owner form to ensure the MessageBox appears above all other windows
        Dim topMostForm As New Form() With {
            .TopMost = True,
            .StartPosition = FormStartPosition.Manual,
            .Location = New Point(-2000, -2000),
            .ShowInTaskbar = False
        }
        ' Show the top-most form
        topMostForm.Show()
        ' Display the MessageBox with the top-most form as its owner
        Dim result As DialogResult = MessageBox.Show(topMostForm, text, caption, buttons, icon)
        ' Close the top-most form after the MessageBox is dismissed
        topMostForm.Close()

        Return result
    End Function

End Class