   M S B A M L   `   `   `  ���� J  FRecipeOrganizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:RecipeViewerRecipeViewer      RecipeViewer.EditRecipe   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:RecipeViewer       � Title$  
EditRecipe��$��638.235��$��707.059��.��� $��0,0,0,-0.333q�$
��Left=�$	��712��.+��� -    ��Name$ label_RecName��$��Title��$��19,3,0,0q�$	��Top=�$��29��$
��Bold"�$��14(�$
��Left=�$	��123���� -    ��Name$ lstVw_Ingredients��$��85��$��21,417,340,0q�$	��Top=��� -    ��Name$ textBox_RecipeDirections��$��401,109,29,93q� �� TextWrapping$
 Wrap=�$ �� HorizontalScrollBarVisibility$
 Auto=�" �� VerticalScrollBarVisibility$
 Auto=��� -   $ lstVw_RecipeType��$��21,104,346,443q��� -   $ textBox_RecipeTitle��$��37��$
 Wrap=�$	��Top=�$
 Auto=�$
 Auto=�$��
20,29,24,0q��� $��
Directions��$��400,71,151,502q�$��14(�$
��Bold"��� $��Ingredients��$��22,334,584,0q�$	��Top=�$
��Bold"�$��14(�$��29���� $��Recipe Type��$��21,66,575,509q� J� RenderTransformOrigin$ 0.049,-0.33&�$��14(�$
��Bold"��� $��Yield��$��
23,163,0,0q�$	��Top=�$��26��$
��Bold"�$
��Left=�$	��217���� -   $ textBox_RecipeYield��$��43��$��
21,195,0,0q�$
 Wrap=�$	��Top=�$
��Left=�$	��345������ *SelectedItem.Yield+ �� ElementName$ listBox_Recipes���� $��Serving Size��$��25,245,474,0q�$	��Top=�$��26��$
��Bold"��� -   $ textBox_RecipeServingSize��$��51��$��23,271,341,0q�$
 Wrap=�$	��Top=��� -   	 ��Name$	 	btnCancel��$��Cancel��$��612,543,55,16q�$ 4.835,0.772&��� -	   $	 btnSave��$
��Save��$��461,543,204,0q�$ 1.549,0.586&�$��46��$	��Top=�z�V� .~��� �� 
 �� AngleX$
 -0.82Q��� T�  T� X$ -2.051Q��� -
   $	 	btnDelete��$��Delete��$��538,541,0,16q�$ 
1.23,0.428&�$
��Left=�$��46���� -   $ textbox_RecipeComment��$��57��$��18,538,340,0q�$	��Top=��� $��Comments��$��23,508,572,0q�$	��Top=�$
��Bold"�$��14(�$��29���� -   $ textBox_Ingredient��$��40��$��23,370,339,0q�$
 Wrap=�$	��Top=��� -   $	 Btn_AddIngredent��$	��Add��$
��Left=�$��199,329,0,0q�$	��Top=�$��75��{�.  $��31��$ -0.111,0.312&��� -   $	 Btn_DelIngredent��$	��Del��$
��Left=�$��293,329,0,0q�$	��Top=�$��75��{�.  $��31��$ -0.778,0.462&��� -   $ textBoxRecipeID_hidden��$
��Left=�$��16��$��	617,5,0,0q�$
 Wrap=�$	��Top=�$��68��$y�Hidden=�