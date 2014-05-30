Module Module1

    Sub Main()
        Utils.Calibrate()
        FullTest()
        'Utils.SetNumberOfProcessors(1)
        

        Console.ReadKey()
    End Sub

    Private Sub InStages()
        Dim sw As Stopwatch = Stopwatch.StartNew()
        'GoulashRecipe.MakeGoulash()
        Console.WriteLine("We're done in {0} minutes.", sw.ElapsedMilliseconds / 60)
    End Sub

    Private Sub FullTest()
        Utils.SuppressOutput = True
        Console.WriteLine("Making sequential goulash")
        Dim sw As Stopwatch = Stopwatch.StartNew()
        GoulashSequential.Cook()
        Console.WriteLine("Sequential goulash finished in {0} minutes", sw.ElapsedMilliseconds / 60)

        Console.WriteLine("Making goulash in steps")
        sw = Stopwatch.StartNew()
        GoulashInSteps.Cook()
        Console.WriteLine("Goulash in steps finished in {0} minutes", sw.ElapsedMilliseconds / 60)

        Console.WriteLine("Making goulash in parallel")
        sw = Stopwatch.StartNew()
        GoulashParallel.Cook()
        Console.WriteLine("Goulash in parallel finished in {0} minutes", sw.ElapsedMilliseconds / 60)

        Console.WriteLine("Making goulash in full parallel")
        sw = Stopwatch.StartNew()
        GoulashFullParallel.Cook()
        Console.WriteLine("Goulash in full parallel finished in {0} minutes", sw.ElapsedMilliseconds / 60)

        GoulashRecipe.ParallelPeelAndDice = True
        Console.WriteLine("Making goulash in full parallel with peel and dice")
        sw = Stopwatch.StartNew()
        GoulashFullParallel.Cook()
        Console.WriteLine("Goulash in full parallel with peel and dice finished in {0} minutes", sw.ElapsedMilliseconds / 60)

        GoulashRecipe.PeelAndDiceAdvanced = True
        Console.WriteLine("Making goulash in full parallel with advanced peel and dice")
        sw = Stopwatch.StartNew()
        GoulashFullParallel.Cook()
        Console.WriteLine("Goulash in full parallel with advanced peel and dice finished in {0} minutes", sw.ElapsedMilliseconds / 60)

        GoulashRecipe.ParallelCutTheMeat = True
        Console.WriteLine("Making goulash with pipelining")
        sw = Stopwatch.StartNew()
        GoulashFullParallel.Cook()
        Console.WriteLine("Goulashwith pipelining finished in {0} minutes", sw.ElapsedMilliseconds / 60)

        Console.WriteLine("All cooking 's done!")
    End Sub

End Module
