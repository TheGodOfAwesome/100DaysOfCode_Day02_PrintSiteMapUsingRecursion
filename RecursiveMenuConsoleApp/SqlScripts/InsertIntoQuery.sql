Use [Learning];
Insert Into dbo.Menu ([Title], [Link]) Values ('Home', '/');
Insert Into dbo.Menu ([Title], [Link]) Values ('Services', '/Services');
Insert Into dbo.Menu ([Title], [Link]) Values ('About', '/About');
Insert Into dbo.Menu ([Title], [Link], [ParentId], [Parent]) Values ('Programming', '/Services/Programming', '1', 'Services');
Insert Into dbo.Menu ([Title], [Link], [ParentId], [Parent]) Values ('Databases', '/Services/Databases', '1', 'Services');
Insert Into dbo.Menu ([Title], [Link], [ParentId], [Parent]) Values ('SQL', '/Services/Databases/Sql', '5', 'Databases');
Insert Into dbo.Menu ([Title], [Link], [ParentId], [Parent]) Values ('MongoDB', '/Services/Databases/MongoDB', '5', 'Databases');