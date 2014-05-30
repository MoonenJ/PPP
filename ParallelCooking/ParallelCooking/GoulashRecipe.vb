
Imports System.Threading.Tasks
Imports System.Diagnostics

Class GoulashRecipe

    Public Shared _parallelPeelAndDice As Boolean

    Public Shared Sub PeelAndDice(ingredients As Ingredient())
        If _parallelPeelAndDice Then
            PeelAndDiceSequential(ingredients)
        Else
            PeelAndDiceSequential(ingredients)
        End If
    End Sub

    Public Shared Sub PeelAndDiceSequential(ingredients As Ingredient())
        Dim ingredientName As String = ingredients.[GetType]().ToString()
        Dim dotPosition As Integer = ingredientName.LastIndexOf("."c) + 1
        ingredientName = ingredientName.Substring(dotPosition, ingredientName.IndexOf("["c) - dotPosition)

        For i As Integer = 0 To ingredients.Length
            Utils.DoWork("Peel And Dice " + ingredientName, 120)
        Next
    End Sub

    Public Shared Function Peel(ingredient As String) As String
        Utils.DoWork(Convert.ToString("Peel ") & ingredient, 60)
        Return ingredient
    End Function

    Public Shared Function Dice(ingredient As String) As String
        Utils.DoWork(Convert.ToString("Dice ") & ingredient, 60)
        Return ingredient
    End Function

    Public Shared Sub PeelAndDiceParallel(ingredients As Ingredient())
        Dim ingredientName As String = ingredients.[GetType]().ToString()
        Dim dotPosition As Integer = ingredientName.LastIndexOf("."c) + 1
        ingredientName = ingredientName.Substring(dotPosition, ingredientName.IndexOf("["c) - dotPosition)


        ' Todo: Step 1 use a loop
        ' Utils.DoWork("Peel And Dice " + ingredientName, 120 * ingredients.Length);

        'for (int i = 0; i < ingredients.Length; i++)
        '{
        '    Utils.DoWork("Peel And Dice " + ingredientName, 120);
        '}

        ' Then parallelize it.
        Parallel.[For](0, ingredients.Length, Sub(i)
                                                  'Utils.DoWork(string.Format("Peel And Dice {0} {1}", ingredientName, i), 120);
                                                  Task.Factory.StartNew(Function() Peel(ingredientName)).ContinueWith(Function(peeled) Dice(peeled.Result), TaskContinuationOptions.AttachedToParent)

                                              End Sub)
    End Sub

    Public Shared Sub DiceTheMeat(meat As Meat())
        CutTheMeatInHalf(0, meat.Length)
    End Sub

    Public Shared Sub CutTheMeatInHalf(start As Integer, length As Integer)
        If length > 1 Then
            Utils.DoWork("Cut the meat in Half", 20)
            Dim half As Integer = length \ 2
            Dim correction As Integer = length Mod 2

            Parallel.Invoke(Sub() CutTheMeatInHalf(start, half), Sub() CutTheMeatInHalf(start + half, half + correction))

        End If
    End Sub

    Public Shared Sub FryTheOnion()
        Utils.DoWork("Fry The Onion", 300)
    End Sub

    Public Shared Sub SprinklePaprika()
        Utils.DoWork("Sprinkle With Paprika", 30)
    End Sub

    Public Shared Sub AddWater()
        Utils.DoWork("Add Water", 30)
    End Sub

    Public Shared Sub AddSomeSpices()
        Utils.DoWork("Add Some Spices", 120)
    End Sub

    Public Shared Sub CutAndCleanTheChilies()
        Utils.DoWork("Cut And Clean The Chillies", 300)
    End Sub

    Public Shared Sub CookThePot(duration As Integer)
        Utils.DoWork("Cook The Pot", duration)
    End Sub

    Public Shared Sub CutThePeppers()
        Utils.DoWork("Cut The Peppers", 120)
    End Sub

End Class