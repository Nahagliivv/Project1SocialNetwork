   M S B A M L   `   `   `  ���� Q  MCourseProjectOOPVer2.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:CourseProjectOOPVer2._0.ViewCourseProjectOOPVer2._0.View  +    %CourseProjectOOPVer2._0.View.PostView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     <local*clr-namespace:CourseProjectOOPVer2._0.View     $
��auto��  � 	Resources   �� MergedDictionaries �� Source��  �� $6 0pack://application:,,,/styles/nostylebutton.xaml?��� $8 2pack://application:,,,/styles/NonStyleTextBox.xaml?�%    .����  �� CornerRadius$ 10�� �� Padding$ 5q�
�������$
��auto��$��Center=�$��0,0,-0.4,0.4q�$	��602�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 20Q�   ShadowDepth$ 0Q�   Opacity$	 0.8Q�._�� 	 � RowDefinitions	 �� $��* ��� $��* ��� $��* �.+��� 
���   �$	��0,1q�$
��Left=�$
��auto��$��2��$��Stretch=�$	��577��$��
5,30,0,0.4q�._��� -   $��PostText��
 �� TextWrapping$

 Wrap=�$��0,9.2,0,8.6q�
���   �   NonStyleText#��[   �� 
IsReadOnly . $��0q����� *Text+�� -   $��UserName��$
��Left=�$��5,1,0,0q�$	��Top=�$
��auto��
���   ����� *UserFullName+� $��Right=�$	��216��$��	0,0,10,23q� � ColumnDefinitions �� $
��189* ��� $
��auto �.+��� -   $��PubDate��$��Right=�$	��Top=�$	��160��$��Right=�
���   �$��0,3,5,0q����� *
PublicDate+�� $
��Left=�$��0,5,0,0q�$	��Top=�$��1��  NonStyle#��[ y��� *DestroyAPostVis+���� *	DelPost+.���� $6��0pack://application:,,,/styles/IcnsPic/Closed.png��$��3��$��20��� $��Right=�$��26��$��
0,0.6,10,0q�$��2��$	��Top=�$
��auto�� �� $
��auto ��� $
��auto �$��20���� $
��auto �$��20���� $
��auto �.+��� $
��Auto��{�. #��[ 
�������
�������$��3��$
��Left=�$��25������ *Like+.���� $��3������ *
LikeStatus+�� $
��Left=�$	��Top=�$
��Left=�$��2������ *LikesNumber+�� $��Right=�$
��Auto��$��	0,0,3.2,0q�{�. #��[ 
�������
�������$��26��$��1������ *
Comments+.���� $7��1pack://application:,,,/styles/IcnsPic/Comment.png��$��2���� $��	0,0,2.6,0q����� *CountOfComments+