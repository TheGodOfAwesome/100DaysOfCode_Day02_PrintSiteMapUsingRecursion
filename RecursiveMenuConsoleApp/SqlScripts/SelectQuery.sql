Use [Learning];
Select * From dbo.Menu;
Select * From dbo.Menu Where dbo.Menu.id > 3;
Select dbo.Menu.Title From dbo.Menu Where dbo.Menu.Parent = 'Services';