Module Module1

    Sub Main()
        Utils.Calibrate()
        'Utils.SetNumberOfProcessors(1)
        Dim sw As Stopwatch = Stopwatch.StartNew()
        'GoulashRecipe.MakeGoulash()
        Console.WriteLine("We're done in {0} minutes.", sw.ElapsedMilliseconds / 60)

        Console.ReadKey()
    End Sub

End Module
