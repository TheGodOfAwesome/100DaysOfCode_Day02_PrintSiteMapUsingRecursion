Use [Learning];
Create Table Menu(
	id				int			Not Null	IDENTITY		Primary Key(id),
	Title			varchar(50)	Not Null,
	Link			varchar(50)	Not Null,
	ParentId 		int			Null		Foreign Key(id) References Menu(id),
	Parent			varchar(50)	Null,
);