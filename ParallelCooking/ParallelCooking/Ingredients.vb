﻿Class Ingredient
End Class
Class Onion
    Inherits Ingredient
End Class
Class Potato
    Inherits Ingredient
End Class
Class Meat
    Inherits Ingredient
End Class
Class Ingredients
    Public Shared Meat As Meat() = New Meat(400) {}
    Public Shared Potatoes As Potato() = New Potato(80) {}
    Public Shared Onions As Onion() = New Onion(60) {}
End Class