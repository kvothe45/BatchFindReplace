   M S B A M L   `   `   `  ����K  GBatchFindReplace, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:BatchFindReplaceBatchFindReplace  5   	   !    BatchFindReplace.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:BatchFindReplace     5   	     � Title$  Find Replace Filenames��5   	   $	��350��6(   $	��525��65   .��5
      � .+�5   
   �� -   5         ��Name$
 path��5      $
��Left=�6"   $��25��6=   $��	10,28,0,0q�6I   $
��Wrap=�6\   $��Path: ��6p   $	��Top=�6~   $��35��6�   �� 5   
   -   5         ��Name$ pathBox��5      $
��Left=�6#   $��25��6>   $��	50,28,0,0q�6J    �� TextWrapping$
 Wrap=�6]   $&�� ex:  c:\users\default\documents\��6q   $	��Top=�6�   $	��326��6�   �� 5   
   -   5         ��Name$ browse��5      $��Browse��6!   $
��Left=�62   $��25��6M   $��
376,28,0,0q�6Y   $	��Top=�6m   $	��112��6�   6�   �� 5   
   -   5        $ findTextBlock��5      $
��Left=�6+   $��19��6F   $��0,91,0,0q�6R   $
��Wrap=�6d   $
��Find��6x   $	��Top=�6�   $��45��6�   �� 5   
   -   5        $ charactersBeforeTextBox��5      $
��Left=�63   $��19��6N   $��	50,91,0,0q�6Z   $
 Wrap=�6m   $�� ��6�    �� TextAlignment$ Center=�6�   $	��Top=�6�   $��30��6�    J� RenderTransformOrigin$ 	1.8,2.674&�6�   �� 5   
   -   5        $ charactersBeforeTextBlock��5      $
��Left=�67   $��35��6R   $��
34,107,0,0q�6^   $
��Wrap=�6r   $��Characters Before��6�    �� TextAlignment$ Center=�6�   $	��Top=�6�   $��62��6�   �� 5   
   -   5        $ plusTextBlock1��5      $
��Left=�6,   $��19��6G   $��	82,91,0,0q�6S   $
��Wrap=�6f   $��+��6z   $ Center=�6�   $	��Top=�6�   $��28��6�   �� 5   
   -   5        $ findTextBox��5      $
��Left=�6'   $��19��6B   $��
110,91,0,0q�6N   $
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��310��6�   �� 5   
   -	   5        $ plusTextBlock2��5      $
��Left=�6,   $��19��6G   $��
425,91,0,0q�6S   $
��Wrap=�6g   $��+��6{   $ Center=�6�   $	��Top=�6�   $��28��6�   �� 5   
   -
   5        $ charactersAfterTextBox��5      $
��Left=�62   $��19��6M   $��
458,91,0,0q�6Y   $
 Wrap=�6m   $�� ��6�   $ Center=�6�   $	��Top=�6�   $��30��6�   �� 5   
   -   5        $ charactersAfterTextBlock��5      $
��Left=�66   $��35��6Q   $��442,107,0,0q�6]   $
��Wrap=�6r   $��Characters After��6�   $ Center=�6�   $	��Top=�6�   $��62��6�   �� 5   
   -   5        $ replaceTextBlock��5      $
��Left=�6.   $��19��6I   $��	0,155,0,0q�6U   $
��Wrap=�6h   $��Replace��6|   $	��Top=�6�   $��45��6�   �� 5   
   -   5        $ replaceTextBox��5      $
��Left=�6*   $��19��6E   $��
50,155,0,0q�6Q   $
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��438��6�   �� 5    
   -   5         ��Name$ numberCheckBox��5       $��Number��6+   $
��Left=�6<   $��16��6W   $��
10,220,0,0q�6c   $	��Top=�6w   $	��119��6�   6�   �� 5"   
   -   5        $ removeNumberCheckBox��5"      $��Remove Numbers��61   $
��Left=�6J   $��16��6e   $��129,220,0,0q�6q   $	��Top=�6�   $	��125��6�   6�   �� 5$   
   -   5        $ processButton��5$      $��Process��6(   $
��Left=�6:   $��27��6U   $��362,284,0,0q�6a   $	��Top=�6v   $	��146��6�   6�   5%      5&      