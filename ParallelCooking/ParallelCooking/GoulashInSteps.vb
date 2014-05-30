Public Class GoulashInSteps
    Public Shared Sub Cook()
        Step1()
        Step2()
        Step3()
        Step4()
    End Sub

    Private Shared Sub Step1()
        GoulashRecipe.PeelAndDice(Ingredients.Onions)
        GoulashRecipe.FryTheOnion()
        GoulashRecipe.SprinklePaprika()
        GoulashRecipe.AddWater()
    End Sub

    Private Shared Sub Step2()
        GoulashRecipe.DiceTheMeat(Ingredients.Meat)
        GoulashRecipe.AddSomeSpices()
        GoulashRecipe.CutAndCleanTheChilies()
        GoulashRecipe.CookThePot(2400)
    End Sub

    Private Shared Sub Step3()
        GoulashRecipe.PeelAndDice(Ingredients.Potatoes)
        GoulashRecipe.CookThePot(600)
    End Sub

    Private Shared Sub Step4()
        GoulashRecipe.CutThePeppers()
        GoulashRecipe.CookThePot(300)
    End Sub


End Class
