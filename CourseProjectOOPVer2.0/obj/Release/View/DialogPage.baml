   M S B A M L   `   `   `  ���� Q  MCourseProjectOOPVer2.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:CourseProjectOOPVer2._0.ViewCourseProjectOOPVer2._0.View  M+clr-namespace:CourseProjectOOPVer2._0.LogicCourseProjectOOPVer2._0.Logic  -    'CourseProjectOOPVer2._0.View.DialogPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     <local*clr-namespace:CourseProjectOOPVer2._0.View     b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  @implementation+clr-namespace:CourseProjectOOPVer2._0.Logic    N� Title$  
MyPagePage�� N� 
Background �#B2F2D0 � 	Resources  �� MergedDictionaries �� Source��  �� $2 ,pack://application:,,,/styles/regbutton.xaml?��� $6 0pack://application:,,,/styles/NostyleButton.xaml?��� $< 6pack://application:,,,/styles/NonSelectedListView.xaml?�%    .��� .+��� 
�������$��Center=�$
��auto��$��Stretch=�$	��602�� �� CornerRadius$ 10��$��339,10q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 20Q�   ShadowDepth$ 0Q�	   Opacity$		 0.8Q�._�� 
 � RowDefinitions
 �� $��55 ��� $
��112* ��� $��55 �.+��� 
���   �$��1q�$
��Left=�$��2��$��0,0.2,-0.4,0q�$��2��$	��Top=�$	��602���� $
��Left=�$��25��$��10,17.2,0,0q�$��2�� �� TextWrapping$
 Wrap=�$	��Top=�$	��545��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$' !Введите сообщение������ *SendedMessage+ �� Mode$ TwoWay=���  �� 	IsDefault . $
��Left=�$��560,16.2,0,0q�$��2��$	��Top=�$��28��$��0q�   NonStyle#��[  $��27������ *SendMessage+.���� $;��5pack://application:,,,/styles/IcnsPic/SendMessage.png��$��27��$��27���� 
���   �$��1q�$
��Left=�$��2��$��0,54,-0.4,0q�$	��Top=�$	��602��$��2��A� $��542,4,13.6,4.2q�����  �� ImageSource �� *ImageSource+�� $��Center=�$��0,15,0,0q�$	��Top=�$��24��$
��auto������ *
UserName+�� $
��Left=�$
��auto��$��0,0.8,-0.4,0q�$��1��$��Stretch=�$	��602��.  (System.Windows.Interactivity.Interaction   	Behaviors 6   0CourseProjectOOPVer2._0.Logic.AutoScrollBehavior  .���� $��Center=�$
��auto��$��Bottom=�$
��1260��$��Center=����� *
Messages+���� .R�.   (CourseProjectOOPVer2._0.View.MessageView  �� $
��Left=�$	��Top=�$��35��$��35��$��	10,10,0,0q�#��[  ���� *	Refresh+.���� $7��1pack://application:,,,/styles/IcnsPic/Refresh.png��