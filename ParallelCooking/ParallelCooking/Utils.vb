Imports System.Diagnostics

NotInheritable Class Utils
    Private Sub New()
    End Sub

    Public Shared SuppressOutput As Boolean

    Private Shared ciclesPerSecond As Long = 127659000
    ''' <summary>
    ''' Simulates som CPU Intensive work ad displays a message on the screen
    ''' </summary>
    ''' <param name="work">What to say to the user</param>
    ''' <param name="seconds">How many "fake" seconds it takes.</param>
    Friend Shared Sub DoWork(work As String, seconds As Integer)
        If Not SuppressOutput Then
            Console.WriteLine("Let's {0} for {1} seconds.", work, seconds)
        End If
        SpinningArround(seconds)
        If Not SuppressOutput Then
            Console.WriteLine("We are done with {0}.", work)
        End If
    End Sub

    ''' <summary>
    ''' Sets the maximum nuber of processors to be used by this application.
    ''' </summary>
    ''' <param name="procs"></param>
    Friend Shared Sub SetNumberOfProcessors(procs As Integer)
        Dim value As Integer = CInt(Math.Pow(2, procs)) - 1
        Process.GetCurrentProcess().ProcessorAffinity = New IntPtr(value)
    End Sub

    ''' <summary>
    ''' Let's see how many cycles we get in on second
    ''' </summary>
    Friend Shared Sub Calibrate()
        Dim sw As Stopwatch = Stopwatch.StartNew()
        SpinningArround(1)
        sw.[Stop]()

        ciclesPerSecond /= CInt(sw.ElapsedMilliseconds)
    End Sub

    ''' <summary>
    ''' Simulates CPU intensive work.
    ''' </summary>
    ''' <param name="seconds">The number of seconds</param>
    ''' <returns></returns>
    Private Shared Function SpinningArround(seconds As Integer) As Integer
        Dim dummyVar As Integer = 0

        For i As Long = 0 To ciclesPerSecond * seconds - 1
            dummyVar += CInt(i) Mod 5
        Next
        Return dummyVar
    End Function
End Class
