INSERT INTO Measure ([Name]) VALUES('CUP'), ('TEASPOON'), ('TABLESPOON');
INSERT INTO Ingredient ([Name]) VALUES('egg'), ('salt'), ('sugar'), ('chocolate'), ('vanilla extract'), ('flour');
INSERT INTO Recipe ([Name], [Description], [Instructions], [CreatedDate]) 
VALUES('Boiled Egg', 'A single boiled egg', 'Add egg to cold water. Bring water to boil. Cook.', CURRENT_TIMESTAMP);
INSERT INTO Recipe ([Name], [Description], [Instructions], [CreatedDate]) 
VALUES('Chocolate Cake', 'Yummy cake', 'Add eggs, flour, chocolate to pan. Bake at 350 for 1 hour', CURRENT_TIMESTAMP);
INSERT INTO RecipeIngredient ([RecipeId], [IngredientId], [MeasureId], [Amount]) VALUES (1, 1, NULL, 1);
INSERT INTO RecipeIngredient ([RecipeId], [IngredientId], [MeasureId], [Amount])  VALUES (2, 1, NULL, 3);
INSERT INTO RecipeIngredient ([RecipeId], [IngredientId], [MeasureId], [Amount])  VALUES (2, 2, 2, 1);
INSERT INTO RecipeIngredient ([RecipeId], [IngredientId], [MeasureId], [Amount])  VALUES (2, 3, 1, 2);
INSERT INTO RecipeIngredient ([RecipeId], [IngredientId], [MeasureId], [Amount])  VALUES (2, 4, 1, 1);