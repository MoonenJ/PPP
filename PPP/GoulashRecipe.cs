namespace PPP
{
    using System.Threading.Tasks;
    using System.Diagnostics;

    static class GoulashRecipe
    {

        internal static void MakeGoulash()
        {
            MakeGoulashParallel();

        }

        private static void MakeGoulashParallel()
        {
            // Step1()
            //PeelAndDice(Ingredients.Onions);
            //FryTheOnion();
            //SprinklePaprika();
            //AddWater();

            Task peelAndDiceOnions = Task.Factory.StartNew(
                ()=> PeelAndDice(Ingredients.Onions));

            Task fryTheOnion = peelAndDiceOnions.ContinueWith(
                _ => FryTheOnion());
            
            Task sprinklePaprika = fryTheOnion.ContinueWith(
                _ => SprinklePaprika());
            
            Task addWater = sprinklePaprika.ContinueWith(
                _ => AddWater());

            // Step2()
            //DiceTheMeat(Ingredients.Meat);
            //AddSomeSpices();
            //CutAndCleanTheChilies();
            //CookThePot(2400);

            Task diceTheMeat = Task.Factory.StartNew(
                () => DiceTheMeat(Ingredients.Meat));

            Task addSomeSpices = Task.Factory.StartNew(
                () => AddSomeSpices());

            Task cutAndCleanTheChilies = Task.Factory.StartNew(
                () => CutAndCleanTheChilies());

            Task cook1 = Task.Factory.ContinueWhenAll(
                new[] { addWater, diceTheMeat, addSomeSpices, cutAndCleanTheChilies },
                _ => CookThePot(2400));


            // Step3()
            //PeelAndDice(Ingredients.Potatoes);
            //CookThePot(600);

            Task peelAndCutPotatoes = Task.Factory.StartNew(
                () => PeelAndDice(Ingredients.Potatoes));

            Task cook2 = Task.Factory.ContinueWhenAll(new[] { cook1, peelAndCutPotatoes },
                _ => CookThePot(600));

            // Step4()
            //CutThePeppers();
            //CookThePot(300);

            Task cutThePeppers = Task.Factory.StartNew(() => CutThePeppers());
            Task finalStep = Task.Factory.ContinueWhenAll(new[] { cook2, cutThePeppers },
                _ => CookThePot(300));
        
            // Done!
            finalStep.Wait();
        }

        private static void PeelAndDice(Ingredient[] ingredients)
        {
            string ingredientName = ingredients.GetType().ToString();
            int dotPosition = ingredientName.LastIndexOf('.') + 1;
            ingredientName = ingredientName.Substring(dotPosition, ingredientName.IndexOf('[') - dotPosition);


            // Todo: Step 1 use a loop
            // Utils.DoWork("Peel And Dice " + ingredientName, 120 * ingredients.Length);

            //for (int i = 0; i < ingredients.Length; i++)
            //{
            //    Utils.DoWork("Peel And Dice " + ingredientName, 120);
            //}

            // Then parallelize it.
            Parallel.For(0, ingredients.Length, i =>
            {
                Task.Factory.StartNew(
                    () => Peel(ingredientName)).ContinueWith(
                    peeled => Dice(peeled.Result), TaskContinuationOptions.AttachedToParent);
                //Utils.DoWork(string.Format("Peel And Dice {0} {1}", ingredientName, i), 120);
            });
        }

        private static string Peel(string ingredient)
        {
            Utils.DoWork("Peel " + ingredient, 60);
            return ingredient;
        }

        private static string Dice(string ingredient)
        {
            Utils.DoWork("Dice " + ingredient, 60);
            return ingredient;
        }

        private static void DiceTheMeat(Meat[] meat)
        {
            //Utils.DoWork("Chop The Meat", 20 * meat.Length);

            // Todo: Step 2 make it recursive
            CutTheMeatInHalf(0, meat.Length);
        }

        public static void CutTheMeatInHalf(int start, int length)
        {
            if (length > 1)
            {
                Utils.DoWork("Cut the meat in Half", 20);
                int half = length / 2;
                int correction = length % 2;

                Parallel.Invoke(
                    ()=>CutTheMeatInHalf(start, half),
                    ()=>CutTheMeatInHalf(start + half, half + correction));
            }
        }

        private static void FryTheOnion()
        {
            Utils.DoWork("Fry The Onion", 300);
        }

        private static void SprinklePaprika()
        {
            Utils.DoWork("Sprinkle With Paprika", 30);
        }

        private static void AddWater()
        {
            Utils.DoWork("Add Water", 30);
        }

        private static void AddSomeSpices()
        {
            Utils.DoWork("Add Some Spices", 120);
        }

        private static void CutAndCleanTheChilies()
        {
            Utils.DoWork("Cut And Clean The Chillies", 300);
        }

        private static void CookThePot(int duration)
        {
            Utils.DoWork("Cook The Pot", duration);
        }

        private static void CutThePeppers()
        {
            Utils.DoWork("Cut The Peppers", 120);
        }

    }
}
