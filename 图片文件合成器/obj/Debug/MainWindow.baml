   M S B A M L   `   `   `  ����  图片文件合成器&     图片文件合成器.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6F   -   5          �Name$  TTMainWindow��5   �    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ 
MainWindow��5   	   $	��280��6   $	��440��6)   $��24q�65    � WindowStyle$
 None=�6J    � AllowsTransparency .  � 
ResizeMode$ NoResize=�6w    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5   
      
BlurRadius$ 24Q�6      Color$ 	#FF858484��6+   	   	Direction$	 90Q�6=   
   ShadowDepth$
 3Q�6L   .��5
      � .+�5   
   �� -   5        
������ .+�5      �� $��图片文件合成器��6    �� Left$	 142��6&   
 �� Top$ 10��68    J� RenderTransformOrigin$ 	1.3,-0.16&�6H   ���	#FF807777$��14(�6�   �� 5      -   5         ��Name$ BtnMin��5      $��20��6$   $	 337��60   $ 10��6B   $��20��6R   $��img/Min.png��6]    � Cursor$
 Hand��6r   6�   �� 5      -   5        $ BtnClose��5      $��20��6&   $	 362��62   $ 10��6D   $��20��6T   $��img/Close.png��6_   $
 Hand��6v   6�   �� 5      -   5        $	 zip��5      $	��100��6!   $	 257��6.   $ 72��6@   $	��100��6P   $��img/zip.png��6\   $
 Hand��6q    � ToolTip$ 选择压缩文件��6�   �� 5      -   5        $	 img��5      $	��100��6!   $ 37��6.   $ 73��6?   $	��100��6O   $��img/img.png��6[   $
 Hand��6p   $ 选择图片文件��6�   �� 5      -   5        $	 add��5      $	��100��6!   $	 150��6.   $ 72��6@   $	��100��6P   $��img/add.png��6\   $
 Hand��6q   $ 合成��6�   �� 5      -   5        $��©2018 TT Software��5      $	 257��60   $	 199��6B   $��23��6S   $	��125��6_   ���	#FF575454$
 Hand��6�   $��12(�6�   $ 打开TT官网��6�   5      5      5      