Public Class GoulashSequential
    Public Sub Cook()

        GoulashRecipe.PeelAndDice(Ingredients.Onions)
        GoulashRecipe.FryTheOnion()
        GoulashRecipe.SprinklePaprika()
        GoulashRecipe.AddWater()

        GoulashRecipe.DiceTheMeat(Ingredients.Meat)
        GoulashRecipe.AddSomeSpices()
        GoulashRecipe.CutAndCleanTheChilies()
        GoulashRecipe.CookThePot(2400)

        GoulashRecipe.PeelAndDice(Ingredients.Potatoes)
        GoulashRecipe.CookThePot(600)

        GoulashRecipe.CutThePeppers()
        GoulashRecipe.CookThePot(300)
    End Sub
End Class
