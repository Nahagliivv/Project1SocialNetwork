   M S B A M L   `   `   `  ���� Q  MCourseProjectOOPVer2.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:CourseProjectOOPVer2._0.ViewCourseProjectOOPVer2._0.View  1    +CourseProjectOOPVer2._0.View.FriendPageView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     <local*clr-namespace:CourseProjectOOPVer2._0.View       N� Title$  
MyPagePage�� N� 
Background �#B2F2D0 � 	Resources  �� MergedDictionaries �� Source��  �� $2 ,pack://application:,,,/styles/regbutton.xaml?��� $6 0pack://application:,,,/styles/NostyleButton.xaml?��� $< 6pack://application:,,,/styles/NonSelectedListView.xaml?�%    .��� .+��� .��� .+��� 
�������$��Center=�$	��310��$	��Top=�$	��272��$��339,10,652.2,0q� �� CornerRadius$ 10�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 20Q�   ShadowDepth$ 0Q�	   Opacity$		 0.8Q�._�� .+��� $
��Left=�$	��255��$��	10,10,0,0q�$	��Top=�$	��252��$
��Fill=����� *
PictureSRC+�� $��14(�$
��Left=�$��
10,273,0,0q�$	��Top=�$	��219��
����������#6BBF90$��0q�$��27������ *FriendStatus+���� *ChangeAFriendStatus+ 
 �� 
TargetType �� Property �� Value��%9   '��       �� "
 ��.���  �@��CornerRadius$ 5���� $
��Left=�$��231,270,0,0q�$	��Top=�$��31��$��30��   NonStyle#��[  ���� *OpenMessageStory+.���� $$��/styles/IcnsPic/MessagePic.png��$��33���� $��Center=�$	��310��$	��Top=�$	��321��$��620,10,322.2,0q�
�������$ 10��   $ 20Q�$ 0Q�$		 0.8Q�._�� .+��� 
���   �$��1q�$
��Left=�$��1��$��0,50,-0.2,0q�$	��Top=�$	��321���� $
��Left=�$��	20,16,0,0q�$	��Top=�$	��291������ *Name+�� $��20,70,208.8,-3.6q�.+��� $��Пол:��$
��Left=�$	��0,3q�$	��Top=�$��80��y��� *SexVis+ �� Mode$ TwoWay=��� $ ��Дата рождения:��$
��Left=�$��0,3,-5,3q�$	��Top=�$��97��y��� *	DateVis+$ TwoWay=��� $��Город:��$
��Left=�$	��0,3q�$	��Top=�$��92��y��� *	CityVis+$ TwoWay=��� $��Страна��$
��Left=�$	��0,3q�$	��Top=�$��92��y��� *
CountryVis+$ TwoWay=��� $��О себе:��$
��Left=�$	��0,3q�$	��Top=�$��92��y��� *
AboutVis+$ TwoWay=��� $��117,70,9.8,0.4q�.+��� $
��Left=�$	��0,3q�$	��Top=�$	��194������ *Sex+$ TwoWay=�y��� *SexVis+$ TwoWay=��� $
��Left=�$	��0,3q�$	��Top=�$	��194������ *
BirthDay+$ TwoWay=�y��� *	DateVis+$ TwoWay=��� $
��Left=�$	��0,3q�$	��Top=�$	��194������ *City+$ TwoWay=�y��� *	CityVis+$ TwoWay=��� $
��Left=�$	��0,3q�$	��Top=�$	��194������ *	Country+$ TwoWay=�y��� *
CountryVis+$ TwoWay=��� $
��Left=�$��3,5,0,5q�$
��Wrap=�$	��Top=�$	��191������ *AboutMyself+$ TwoWay=�y��� *
AboutVis+$ TwoWay=��� $��Center=�$
��auto��$	��Top=�$
��1260��$��10,325,-6.8,0q�$��Center=����� *PostsCollection+���� .R�+   %CourseProjectOOPVer2._0.View.PostView  