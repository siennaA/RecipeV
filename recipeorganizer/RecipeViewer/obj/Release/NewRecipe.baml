   M S B A M L   `   `   `  ���� J  FRecipeOrganizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:RecipeViewerRecipeViewer      RecipeViewer.NewRecipe   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:RecipeViewer       � Title$  
New Recipe��$��639.251��$��735.385�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ CanResizeWithGrip=� � SizeToContent$ WidthAndHeight=�.��� $��0,0,0,-0.333q�.+��� -    ��Name$ label_RecName��$��Title��$��
19,3,594,0q�$	��Top=�$��29��$
��Bold"�$��14(��� -    ��Name$ lstVw_Ingredients��$��85��$��21,417,366.667,0q�$	��Top=��� -    ��Name$ textBox_RecipeDirections��$��401,99,8.667,93.333q� �� TextWrapping$
 Wrap=�$ �� HorizontalScrollBarVisibility$
 Auto=�"	 �� VerticalScrollBarVisibility$
	 Auto=��� -   $ lstVw_RecipeType��$��21,101,365.667,451.333q��� -   $ textBox_RecipeTitle��$��37��$
 Wrap=�$	��Top=�$
 Auto=�$
	 Auto=�$��20,29,6.667,0q��� $��
Directions��$��400,71,86,508.333q�$��14(�$
��Bold"��� $��Ingredients��$��22,334,591,0q�$	��Top=�$
��Bold"�$��14(�$��29���� $��Recipe Type��$��21,75,557,507.333q�
 J� RenderTransformOrigin$
 0.049,-0.33&�$��14(�$
��Bold"��� $��Yield��$��21,169,606,0q�$	��Top=�$��26��$
��Bold"��� -   $ textBox_RecipeYield��$��43��$��21,195,367.667,0q�$
 Wrap=�$	��Top=����� *SelectedItem.Yield+ �� ElementName$ listBox_Recipes���� $��Serving Size��$��25,245,623.667,0q�$	��Top=�$��26��$
��Bold"��� -   $ textBox_RecipeServingSize��$��51��$��23,271,367.667,0q�$
 Wrap=�$	��Top=��� -    ��Name$ 	btnCancel��$��Cancel��$��640,536,31.667,18.333q�$
 4.835,0.772&��� -	   $ btnSave��$
��Save��$��536,536,129.667,17.333q�$
 1.549,0.586&��� -
   $ btnReset��$��Reset��$��438,537,231.667,16.333q��� -   $ textbox_RecipeComment��$��57��$��18,538,366.667,0q�$	��Top=��� $��Comments��$��23,508,589.667,0q�$	��Top=�$
��Bold"�$��14(�$��29���� -   $ textBox_Ingredient��$��40��$��23,370,367.667,0q�$
 Wrap=�$	��Top=��� -   $ Btn_AddIngredent��$	��Add��$
��Left=�$��199,329,0,0q�$	��Top=�$��75��{�.  $��31��$
 -0.111,0.312&��� -   $ Btn_DelIngredent��$	��Del��$
��Left=�$��284,329,0,0q�$	��Top=�$��75��{�.  $��31��$
 -0.778,0.462&�