   M S B A M L   `   `   `  ����J  FRecipeOrganizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:RecipeViewerRecipeViewer  5   	       RecipeViewer.NewRecipe   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:RecipeViewer     5   	     � Title$  
New Recipe��5   	   $��639.251��6   $��735.385��6-    � WindowStartupLocation$ CenterScreen=�6=    � 
ResizeMode$ CanResizeWithGrip=�6b    � SizeToContent$ WidthAndHeight=�6�   .��5	      � $��0,0,0,-0.333q�6   .+�5
   
   �� -   5         ��Name$ label_RecName��5
      $��Title��6'   $��
19,3,594,0q�67   $	��Top=�6K   $��29��6c   $
��Bold"�6o   $��14(�6�   �� 5   
   -   5         ��Name$ lstVw_Ingredients��5      $��85��6/   $��21,417,366.667,0q�6;   $	��Top=�6U   6m   �� 5   
   -   5         ��Name$ textBox_RecipeDirections��5      $��401,99,8.667,93.333q�65    �� TextWrapping$
 Wrap=�6R   $ �� HorizontalScrollBarVisibility$
 Auto=�6f   "	 �� VerticalScrollBarVisibility$
	 Auto=�6�   �� 5   
   -   5        $ lstVw_RecipeType��5      $��21,101,365.667,451.333q�6.   �� 5   
   -   5        $ textBox_RecipeTitle��5      $��37��60   $
 Wrap=�6<   $	��Top=�6P   $
 Auto=�6h   $
	 Auto=�6�   $��20,29,6.667,0q�6�   �� 5   
   $��
Directions��6   $��400,71,86,508.333q�6%   $��14(�6@   $
��Bold"�6N   �� 5   
   $��Ingredients��6   $��22,334,591,0q�6&   $	��Top=�6<   $
��Bold"�6T   $��14(�6f   $��29��6t   �� 5   
   $��Recipe Type��6   $��21,75,557,507.333q�6&   
 J� RenderTransformOrigin$
 0.049,-0.33&�6A   $��14(�6e   $
��Bold"�6s   �� 5   
   $��Yield��6   $��21,169,606,0q�6    $	��Top=�66   $��26��6N   $
��Bold"�6Z   �� 5   
   -   5        $ textBox_RecipeYield��5      $��43��6p   $��21,195,367.667,0q�6|   $
 Wrap=�6�   $	��Top=�6�   ��6/   �� *SelectedItem.Yield+ �� ElementName$ listBox_Recipes��6�   �� 5   
   $��Serving Size��6   $��25,245,623.667,0q�6'   $	��Top=�6A   $��26��6Y   $
��Bold"�6e   �� 5   
   -   5        $ textBox_RecipeServingSize��5      $��51��66   $��23,271,367.667,0q�6B   $
 Wrap=�6\   $	��Top=�6p   �� 5   
   -   5         ��Name$ 	btnCancel��5      $��Cancel��6$   $��640,536,31.667,18.333q�65   $
 4.835,0.772&�6T   6x   �� 5   
   -	   5        $ btnSave��5      $
��Save��6"   $��536,536,129.667,17.333q�61   $
 1.549,0.586&�6Q   6u   �� 5   
   -
   5        $ btnReset��5      $��Reset��6#   $��438,537,231.667,16.333q�63   6S   �� 5   
   -   5        $ textbox_RecipeComment��5      $��57��62   $��18,538,366.667,0q�6>   $	��Top=�6X   �� 5   
   $��Comments��6   $��23,508,589.667,0q�6#   $	��Top=�6=   $
��Bold"�6U   $��14(�6g   $��29��6u   �� 5   
   -   5        $ textBox_Ingredient��5      $��40��6/   $��23,370,367.667,0q�6;   $
 Wrap=�6U   $	��Top=�6i   6�   �� 5   
   -   5        $ Btn_AddIngredent��5      $	��Add��6+   $
��Left=�69   $��199,329,0,0q�6T   $	��Top=�6i   $��75��6�   {�.  $��31��6�   $
 -0.111,0.312&�6�   �� 5   
   -   5        $ Btn_DelIngredent��5      $	��Del��6+   $
��Left=�69   $��284,329,0,0q�6T   $	��Top=�6i   $��75��6�   {�.  $��31��6�   $
 -0.778,0.462&�6�   5      5       