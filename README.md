# C-lvl2-Employee
1. БД Lesson7_190818

2. Две таблицы:
	Employee
	 CREATE TABLE [dbo].[Employee] (
   		[Id]      INT            IDENTITY (1, 1) NOT NULL,
   		[Surname] NVARCHAR (MAX) COLLATE Cyrillic_General_CI_AS NOT NULL,
    		[Name]    NVARCHAR (MAX) COLLATE Cyrillic_General_CI_AS NOT NULL,
    		[Age]     NVARCHAR (100) NOT NULL,
   		[Dep]     NVARCHAR (100) NOT NULL,
   		CONSTRAINT [PK_dbo.Employee] PRIMARY KEY CLUSTERED ([Id] ASC)
	 );
	Department
	CREATE TABLE [dbo].[Department] (
    		[Id]      INT            IDENTITY (1, 1) NOT NULL,
   		[DepName] NVARCHAR (MAX) COLLATE Cyrillic_General_CI_AS NOT NULL,
    		[DepNum]  NVARCHAR (100) NOT NULL,
  		CONSTRAINT [PK_dbo.Department] PRIMARY KEY CLUSTERED ([Id] ASC)
	);

3. Для заполнения тестовыми данными в классе MainWindow расскоментировать строки:
	
	#region Заполнение таблиц
        //FillDepartment();
        //FillEmployee();
        #endregion
