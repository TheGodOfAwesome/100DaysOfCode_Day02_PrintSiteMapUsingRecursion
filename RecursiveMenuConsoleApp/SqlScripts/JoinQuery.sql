Use Learning;

Create Table [Action](
	id				int			Not Null	IDENTITY		Primary Key(id),
	[Name]			varchar(50)	Not Null
);

Create Table Animal(
	id				int			Not Null	IDENTITY		Primary Key(id),
	[Name]			varchar(50)	Not Null,
	ActionId 		int			Null		Foreign Key(id) References Action(id)
);

Insert Into dbo.Action([Name]) Values ('Walk');
Insert Into dbo.Action([Name]) Values ('Fly');
Insert Into dbo.Action([Name]) Values ('Swim');

Insert Into dbo.Animal([Name], ActionId) Values ('Cat', 1);
Insert Into dbo.Animal([Name], ActionId) Values ('Bacteria', Null);
Insert Into dbo.Animal([Name], ActionId) Values ('Falcon', 2);

Select a.id ActionID, a.Name [Action],  al.id AnimalId, al.Name AnimalName, al.ActionId ReferenceActionId 
From Action a
Left Join Animal al 
ON a.id=al.ActionId;

Select a.id ActionID, a.Name [Action],  al.id AnimalId, al.Name AnimalName, al.ActionId ReferenceActionId 
From Action a
Right Join Animal al 
ON a.id=al.ActionId;

Select a.id ActionID, a.Name [Action],  al.id AnimalId, al.Name AnimalName, al.ActionId ReferenceActionId 
From Action a
Inner Join Animal al 
ON a.id=al.ActionId;

Select a.id ActionID, a.Name [Action],  al.id AnimalId, al.Name AnimalName, al.ActionId ReferenceActionId 
From Action a
Full Outer Join Animal al 
ON a.id=al.ActionId;