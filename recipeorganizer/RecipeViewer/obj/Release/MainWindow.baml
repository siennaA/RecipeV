   M S B A M L   `   `   `  ���� J  FRecipeOrganizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:RecipeViewerRecipeViewer      RecipeViewer.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:RecipeViewer     -     � Title$  Recipe Viewer�� � WindowStyle$ 
ToolWindow=� � SizeToContent$ Height=� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ CanResizeWithGrip=�$��799.667��$��679.258�� � 	Resources  
  CoView �� Source �� Path  Head��%U   &	        &	      ��  �� $ Recipes��� .R��� ���� *
RecipeType+.��� $��0,0,-15.667,-0.333q� � ColumnDefinitions �� $	��15* ��� $	��67* ��� $
��321* �.+��� -   	 ��Name$	 listBox_Recipes��
 �� SelectedIndex$
 0��$
��Left=�$	��366��$��
10,109,0,0q�$	��Top=�$	��215��$��3������  �� Source# [   �� 
GroupStyle (  "System.Windows.Controls.GroupStyle     HeaderTemplate# [ �� -    ��Name$ label_RecName��$��Recipe Type��$��67.333,80,397.333,0q�$	��Top=�$��29��$
��Bold"�$��14(�$��2���� -   $ label_RecipesList��$��Select a Recipe
��$��11,80,623.333,518.666q�$
��Bold"�$��14(�$��3���� -    ��Name$ lstVw_Ingredients��$	��162��$��66.333,314,337.333,0q�$	��Top=�$��2������ *SelectedItem.Ingredients+ �� ElementName$ listBox_Recipes���� -    ��Name$ textBox_Directions��$	��366��$��312.333,110,24.333,0q� �� TextWrapping$
 Wrap=�$	��Top=�$ �� HorizontalScrollBarVisibility$
 Auto=�" �� VerticalScrollBarVisibility$
 Auto=�$��2������ *SelectedItem.Directions+$ listBox_Recipes���� -   $ textBox_Comments��$
��Left=�$��67��$��
10,505,0,0q�$
 Wrap=�$	��Top=�$	��461��$
 Auto=�$��3������ *SelectedItem.Comment+$ listBox_Recipes���� -   $ textBox_RecipeType��$��32��$
 Wrap=�$	��Top=�$
 Auto=�$
 Auto=�$��66.333,110,337.333,0q�$��2������ *SelectedItem.RecipeType+$ listBox_Recipes���� $��
Directions��$��312.333,78,24.333,0q�$	��Top=�$��14(�$
��Bold"�$��2��$��29���� $��Ingredients��$��67.333,284,397.333,0q�$	��Top=�$
��Bold"�$��14(�$��2��$��29���� $��Comment��$
��Left=�$��
10,477,0,0q�$	��Top=� J� RenderTransformOrigin$ 0.049,-0.33&�$	��215��$��14(�$
��Bold"�$��3��$��29��� $��57��$��9,10,25.333,0q�$	��Top=�$��3��.+��� -	    ��Name$ 
exitButton��$
��Exit��$��Right=�$��0,-1,0,4q�$��Stretch=�$��59��$��54���� -
   $ 	btnSearch��$��Search��$��
0,-1,703,0q�$	��Top=�$��54��$��Right=�$��59���� -   $ 
btnRefresh��$��Refresh��$��103,0,605,3q�$��54���� -   $ 	btnDelete��$��Delete��$��416,0,284,3q�$ 4.835,0.772&�$��54���� -   $ btnEdit��$
��Edit��$��309,0,392,3q�$ 1.549,0.586&�$��54���� -   $ btnNew��$	��New��$��200,0,505,3q�$��54���� -   $ textBoxNotifications��$
��Left=�$��318.333,527,0,0q�$
 Wrap=�$	��Top=�$��42��$	��301��$��2��.������  �� Color# � ��.������ # � ��.���� $��Yield��$��66.333,144,412.333,0q�$	��Top=�$��2��$��26��$
��Bold"��� -   $ textBox_Yield��$��28��$��66.333,170,337.333,0q�$
 Wrap=�$	��Top=�$��2������ *SelectedItem.Yield+$ listBox_Recipes���� $��Serving Size��$��66.333,198,470.333,0q�$	��Top=�$��2��$��26��$
��Bold"��� -   $ textBox_ServingSize��$��51��$��66.333,229,337.333,0q�$
 Wrap=�$	��Top=�$��2������ *SelectedItem.ServingSize+$ listBox_Recipes���� -   $ textBoxID_hidden��$��2��$
��Left=�$��23��$��15.333,82,0,0q�$
 Wrap=�$	��Top=�$��39��$y�Hidden=����� *SelectedItem.RecipeID+$ listBox_Recipes��