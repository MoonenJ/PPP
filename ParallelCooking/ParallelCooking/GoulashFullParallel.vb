Public Class GoulashFullParallel

    Public Shared Sub Cook()
        Dim peelAndDiceOnions As Task = Task.Factory.StartNew(Sub() GoulashRecipe.PeelAndDice(Ingredients.Onions))
        Dim fryTheOnion__1 As Task = peelAndDiceOnions.ContinueWith(Sub() GoulashRecipe.FryTheOnion())
        Dim sprinklePaprika__2 As Task = fryTheOnion__1.ContinueWith(Sub() GoulashRecipe.SprinklePaprika())
        Dim addWater__3 As Task = sprinklePaprika__2.ContinueWith(Sub() GoulashRecipe.AddWater())

        Dim diceTheMeat__4 As Task = Task.Factory.StartNew(Sub() GoulashRecipe.DiceTheMeat(Ingredients.Meat))
        Dim addSomeSpices__5 As Task = Task.Factory.StartNew(Sub() GoulashRecipe.AddSomeSpices())
        Dim cutAndCleanTheChilies__6 As Task = Task.Factory.StartNew(Sub() GoulashRecipe.CutAndCleanTheChilies())

        Dim cook1Tasks = New List(Of Task) From {addWater__3, diceTheMeat__4, addSomeSpices__5, cutAndCleanTheChilies__6}
        Dim cook1 As Task = Task.Factory.ContinueWhenAll(cook1Tasks.ToArray, Sub() GoulashRecipe.CookThePot(2400))

        Dim peelAndCutPotatoes As Task = Task.Factory.StartNew(Sub() GoulashRecipe.PeelAndDice(Ingredients.Potatoes))

        Dim cook2Tasks = New List(Of Task) From {cook1, peelAndCutPotatoes}
        Dim cook2 As Task = Task.Factory.ContinueWhenAll(cook2Tasks.ToArray, Sub() GoulashRecipe.CookThePot(600))

        Dim cutThePeppers__7 As Task = Task.Factory.StartNew(Sub() GoulashRecipe.CutThePeppers())

        Dim finalTasks = New List(Of Task) From {cook2, cutThePeppers__7}
        Dim finalStep As Task = Task.Factory.ContinueWhenAll(finalTasks.ToArray, Sub() GoulashRecipe.CookThePot(300))

        finalStep.Wait()
    End Sub
End Class
