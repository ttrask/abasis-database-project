USE [COP4710]
GO
/****** Object:  Table [dbo].[Forms]    Script Date: 11/26/2011 14:14:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Forms](
	[FormID] [int] IDENTITY(1000,1) NOT NULL,
	[CreateUser] [char](20) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UnitNumber] [nchar](10) NOT NULL,
	[County] [nchar](10) NULL,
 CONSTRAINT [Forms_pk] PRIMARY KEY CLUSTERED 
(
	[FormID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/26/2011 14:14:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1000,1) NOT NULL,
	[UserName] [char](20) NOT NULL,
	[Password] [char](20) NOT NULL,
	[FirstName] [char](40) NOT NULL,
	[LastName] [char](40) NULL,
	[AccountType] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DispatchNumber] [int] NULL,
 CONSTRAINT [Users_pk] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT [dbo].[Users] ([UserID], [UserName], [Password], [FirstName], [LastName], [AccountType], [IsActive], [DispatchNumber]) VALUES (1000, N'ttrask              ', N'iamtom              ', N'Thomas                                  ', N'Trask                                   ', 1, 1, NULL)
INSERT [dbo].[Users] ([UserID], [UserName], [Password], [FirstName], [LastName], [AccountType], [IsActive], [DispatchNumber]) VALUES (1001, N'admin               ', N'admin               ', N'Administrator                           ', N'                                        ', 2, 1, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 11/26/2011 14:14:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateUser]
	@Username nvarchar(20)
	,@Password nvarchar(20)
	,@Firstname nvarchar(20)
	,@Lastname nvarchar(20)
	,@IsActive bit
	,@AccountType tinyint
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	
	Declare @UserId int = 0
	Set @UserId = Coalesce((Select UserID from dbo.[User] where Username = @Username), 0)
	
	if(@UserID=0)
	BEGIN
		INSERT INTO [USER] (Username, Password, FirstName, LastName, IsActive, AccountType)
		VALUES
		(
		@Username, @Password, @Firstname, @Lastname, @IsActive, @AccountType
		)
	END

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 11/26/2011 14:14:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUser]
	@Username nvarchar(20)
	,@Password nvarchar(20) = null
	,@Firstname nvarchar(20) = null
	,@Lastname nvarchar(20) = null
	,@IsActive bit = null
	,@AccountType tinyint = null
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	
		Update Users set 
			Password=Coalesce(@Password, Password)
			, FirstName= Coalesce(@FirstName, FirstName)
			, LastName = Coalesce(@LastName, LastName)
			, IsActive = Coalesce(@IsActive, IsActive)
			, AccountType = Coalesce(@AccountType, AccountType)
			
		where 
		UserName=@Username
	

END
GO
/****** Object:  Table [dbo].[CrashInfo]    Script Date: 11/26/2011 14:14:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CrashInfo](
	[FormId] [int] NOT NULL,
	[Driver_Restrained] [nchar](15) NULL,
	[Passenger_Restrained] [nchar](20) NULL,
	[Speed] [tinyint] NULL,
	[Helmet] [bit] NULL,
	[Airbag] [bit] NULL,
	[PKG] [bit] NULL,
	[Rollover] [bit] NULL,
	[Entrapped] [bit] NULL,
	[Ejected] [bit] NULL,
 CONSTRAINT [MVC_pk] PRIMARY KEY CLUSTERED 
(
	[FormId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AuthenticateUser]    Script Date: 11/26/2011 14:14:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AuthenticateUser]
	-- Add the parameters for the stored procedure here
	@Username nvarchar(20),
	@Password nvarchar(20)
	
	AS
BEGIN
	select top 1 * from [Users] where UserName=@Username
		and Password=@Password
END
GO
/****** Object:  Table [dbo].[Alert]    Script Date: 11/26/2011 14:14:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Alert](
	[FormId] [int] NOT NULL,
	[TA] [bit] NULL,
	[SA] [bit] NULL,
	[STEMI] [bit] NULL,
	[TIBR] [char](20) NULL,
	[HX] [tinyint] NULL,
	[TX] [tinyint] NULL,
	[DISP] [char](20) NULL,
	[ETA] [tinyint] NULL,
	[Notified] [bit] NULL,
	[Onset] [char](20) NULL,
	[Resus] [bit] NULL,
 CONSTRAINT [Alerts_pk] PRIMARY KEY CLUSTERED 
(
	[FormId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MedicalDetail]    Script Date: 11/26/2011 14:14:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MedicalDetail](
	[FormId] [int] NOT NULL,
	[Detail] [char](255) NULL,
	[Levels] [char](1) NULL,
	[Destination] [char](15) NULL,
	[CardiacRed] [bit] NULL,
 CONSTRAINT [MedicalDetail_pk] PRIMARY KEY CLUSTERED 
(
	[FormId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MedicalControl]    Script Date: 11/26/2011 14:14:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MedicalControl](
	[FormId] [int] NOT NULL,
	[Rescue] [char](20) NULL,
	[Meds] [char](50) NULL,
	[DrSign] [char](20) NULL,
	[DEANumber] [int] NULL,
	[NARC] [bit] NULL,
 CONSTRAINT [MedicalControl_pk] PRIMARY KEY CLUSTERED 
(
	[FormId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[ListUsers]    Script Date: 11/26/2011 14:14:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListUsers]
	-- Add the parameters for the stored procedure here
	AS
BEGIN
	select * from [Users]
END
GO
/****** Object:  StoredProcedure [dbo].[ListForms]    Script Date: 11/26/2011 14:14:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListForms]
		@Page int = null,
		@PageSize int=20
	AS
BEGIN
	
	if(@Page>=0)
	begin
		Declare @StartPage int = @Page * @PageSize;
		Declare @EndPage int = (@Page+1) * @PageSize;
		
		
		With pagedforms AS 
     ( SELECT *, 
       ROW_NUMBER() OVER (order by CreateDate Desc) as RowNumber 
       FROM [Forms] ) 

		select * from pagedforms where RowNumber>=@StartPage and RowNumber<@EndPage
		
	end
	else
	begin
	
		select distinct * from [Forms] order by CreateDate desc
	end
END
GO
/****** Object:  Table [dbo].[InitialDiagnosis]    Script Date: 11/26/2011 14:14:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InitialDiagnosis](
	[FormId] [int] NOT NULL,
	[Age] [int] NULL,
	[AgeType] [nvarchar](10) NULL,
	[Sex] [char](1) NULL,
	[AnOX] [tinyint] NULL,
	[BP] [nvarchar](10) NULL,
	[BP2] [nvarchar](10) NULL,
	[Pulse] [smallint] NULL,
	[Pulse2] [smallint] NULL,
	[Resp2] [tinyint] NULL,
	[Resp] [tinyint] NULL,
	[O2Sat2] [tinyint] NULL,
	[O2Sat] [tinyint] NULL,
	[Category] [nvarchar](50) NULL,
	[CC] [nvarchar](100) NULL,
	[Loc] [bit] NULL,
	[GCS] [int] NULL,
	[BGL1] [int] NULL,
	[BLG2] [int] NULL,
 CONSTRAINT [InitialDiagnosis_pk] PRIMARY KEY CLUSTERED 
(
	[FormId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[GetUserByUsername]    Script Date: 11/26/2011 14:14:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserByUsername]
	-- Add the parameters for the stored procedure here
	@Username nvarchar(20)
	AS
BEGIN
	select top 1 * from [Users] where UserName=@Username
END
GO
/****** Object:  StoredProcedure [dbo].[GetFormByID]    Script Date: 11/26/2011 14:14:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetFormByID]
	
		@FormID int
	AS
BEGIN
	select * from [Forms] F 
		left join CrashInfo C on C.FormId = F.FormID
		left join Alert A on A.FormId = F.FormID
		left join InitialDiagnosis I on I.FormId = F.FormID
		left join MedicalControl MC on MC.FormId = F.FormID
		left join MedicalDetail MD on MD.FormId = F.FormID
	where F.FormID = @FormID
END
GO
/****** Object:  StoredProcedure [dbo].[CreateForm]    Script Date: 11/26/2011 14:14:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateForm]
	@CreateUser nvarchar(20)
	,@CreateDate DateTime
	,@UnitNumber int
	,@County NVARCHAR(20) = null
	,@Age int = null
	,@AgeType nvarchar(10)= null
	,@Sex char(1)= null
	,@AnOX tinyint= null
	,@BP nvarchar(10)= null
	,@BP2 nvarchar(10)= null
	,@Pulse smallint= null
	,@Pulse2 smallint= null
	,@Resp tinyint= null
	,@Resp2 tinyint= null
	,@O2Sat tinyint= null
	,@O2Sat2 tinyint= null
	,@Category nvarchar(50)= null
	,@CC nvarchar(100)= null
	,@LOC bit= null
	,@GCS int= null
	,@BLG1 int= null
	,@BLG2 int = null
	,@DriverRestrained nchar(15)= null
	,@PassengerRestrained nchar(20)= null
	,@speed tinyint= null
	,@Helmet bit= null
	,@Airbag bit= null
	,@PKG bit= null
	,@Rollover bit = null
	,@Entrapped bit = null
	,@Ejected bit = null
	,@TraumaAlert bit= null
	,@StrokeAlert bit= null
	,@Onset time= null
	,@STEMI bit= null
	,@TIBR bit= null
	,@Dispatcher NVARCHAR(40)= null
	,@History tinyint= null
	,@Treatment tinyint= null
	,@Notified bit= null
	,@ETA tinyint= null
	,@Rescue char(20) = null
	,@Meds char(50)= null
	,@DrSignature char(40)= null
	,@DEANumber int= null
	,@NARC char(20)= null
	,@Detail char(400)= null
	,@Level char(2)= null
	,@Destination tinyint= null
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	
	Declare @FormID int = 0
	
	Insert into Forms ( CreateUser, CreateDate, UnitNumber, County)
		values
			(@CreateUser, @CreateDate, @UnitNumber, @County)
	
	
	Set @FormID = SCOPE_IDENTITY()
	SELECT @FormID;
	
	Insert into dbo.InitialDiagnosis
		( 
		 FormId, Age, AgeType, Sex, AnOX, BGL1, BLG2, BP, BP2, CC, Category, Pulse, Pulse2, Resp, Resp2, O2Sat, O2Sat2, Loc, GCS
		)
	values
		(@FormID, @Age, @AgeType, @Sex, @AnOX, @BLG1, @BLG2, @BP, @BP2, @CC, @Category, @Pulse, @Pulse2, @Resp, @Resp2, @O2Sat, @O2Sat2, @LOC, @GCS)
		
	Insert into dbo.CrashInfo
		(	
			FormId, Driver_Restrained, Passenger_Restrained, Speed, Helmet, Airbag, PKG, Rollover, Entrapped, Ejected
		)
	values
		(
			@Formid,@DriverRestrained, @PassengerRestrained, @speed, @Helmet, @Airbag, @PKG, @Rollover, @Entrapped, @Ejected
		)
	
	insert into dbo.Alert
		(
			Formid, TA, SA, STEMI, TIBR, HX, TX, Onset, ETA, Disp, Notified
		)
	values
		(
			@Formid, @TraumaAlert, @StrokeAlert, @STEMI, @TIBR, @History, @Treatment
			,@Onset, @ETA, @Dispatcher, @Notified
		)
		
	insert into MedicalControl
		(
			FormId, Rescue, Meds, DrSign, DEANumber, NARC
		)
	values
		(
			@Formid, @Rescue, @Meds, @DrSignature, @DEANumber, @NARC
		)
	
	insert into MedicalDetail
		(
			FormId, Detail, Levels, Destination
		)
		values(
			@FormID, @Detail, @Level, @Destination
		)
END
GO
/****** Object:  View [dbo].[vwForms]    Script Date: 11/26/2011 14:14:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwForms]
AS
SELECT     dbo.MedicalControl.Rescue, dbo.MedicalControl.DrSign, dbo.MedicalControl.Meds, dbo.MedicalControl.DEANumber, dbo.MedicalControl.NARC, 
                      dbo.CrashInfo.Driver_Restrained, dbo.CrashInfo.Passenger_Restrained, dbo.CrashInfo.Speed, dbo.CrashInfo.Helmet, dbo.CrashInfo.Airbag, dbo.CrashInfo.PKG, 
                      dbo.CrashInfo.Rollover, dbo.CrashInfo.Ejected, dbo.CrashInfo.Entrapped, dbo.Forms.CreateUser, dbo.Forms.CreateDate, dbo.Forms.UnitNumber, dbo.Forms.County, 
                      dbo.MedicalDetail.Detail, dbo.MedicalDetail.Levels, dbo.MedicalDetail.Destination, dbo.Alert.TA, dbo.Alert.SA, dbo.Alert.STEMI, dbo.Alert.TIBR, dbo.Alert.HX, 
                      dbo.Alert.TX, dbo.Alert.DISP, dbo.Alert.ETA, dbo.Alert.Notified, dbo.Alert.Onset, dbo.InitialDiagnosis.Age, dbo.InitialDiagnosis.AgeType, dbo.InitialDiagnosis.Sex, 
                      dbo.InitialDiagnosis.AnOX, dbo.InitialDiagnosis.BP, dbo.InitialDiagnosis.BP2, dbo.InitialDiagnosis.Pulse, dbo.InitialDiagnosis.Pulse2, dbo.InitialDiagnosis.Resp2, 
                      dbo.InitialDiagnosis.Resp, dbo.InitialDiagnosis.O2Sat2, dbo.InitialDiagnosis.O2Sat, dbo.InitialDiagnosis.Category, dbo.InitialDiagnosis.CC, dbo.InitialDiagnosis.Loc, 
                      dbo.InitialDiagnosis.GCS, dbo.InitialDiagnosis.BGL1, dbo.InitialDiagnosis.BLG2
FROM         dbo.Alert INNER JOIN
                      dbo.CrashInfo ON dbo.Alert.FormId = dbo.CrashInfo.FormId INNER JOIN
                      dbo.Forms ON dbo.Alert.FormId = dbo.Forms.FormID AND dbo.CrashInfo.FormId = dbo.Forms.FormID INNER JOIN
                      dbo.InitialDiagnosis ON dbo.Forms.FormID = dbo.InitialDiagnosis.FormId INNER JOIN
                      dbo.MedicalControl ON dbo.Forms.FormID = dbo.MedicalControl.FormId INNER JOIN
                      dbo.MedicalDetail ON dbo.Forms.FormID = dbo.MedicalDetail.FormId
GO
/****** Object:  StoredProcedure [dbo].[UpdateFormByID]    Script Date: 11/26/2011 14:14:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateFormByID]
	@FormID int
	,@CreateUser nvarchar(20)
	,@CreateDate DateTime
	,@UnitNumber int
	,@County NVARCHAR(20) = null
	,@Age int = null
	,@AgeType nvarchar(10)= null
	,@Sex char(1)= null
	,@AnOX tinyint= null
	,@BP nvarchar(10)= null
	,@BP2 nvarchar(10)= null
	,@Pulse smallint= null
	,@Pulse2 smallint= null
	,@Resp tinyint= null
	,@Resp2 tinyint= null
	,@O2Sat tinyint= null
	,@O2Sat2 tinyint= null
	,@Category nvarchar(50)= null
	,@CC nvarchar(100)= null
	,@LOC bit= null
	,@GCS int= null
	,@BLG1 int= null
	,@BLG2 int = null
	,@DriverRestrained nchar(15)= null
	,@PassengerRestrained nchar(20)= null
	,@speed tinyint= null
	,@Helmet bit= null
	,@Airbag bit= null
	,@PKG bit= null
	,@Rollover bit = null
	,@Entrapped bit = null
	,@Ejected bit = null
	,@TraumaAlert bit= null
	,@StrokeAlert bit= null
	,@Onset time= null
	,@STEMI bit= null
	,@TIBR bit= null
	,@Dispatcher NVARCHAR(40)= null
	,@History tinyint= null
	,@Treatment tinyint= null
	,@Notified bit= null
	,@ETA tinyint= null
	,@Rescue char(20) = null
	,@Meds char(50)= null
	,@DrSignature char(40)= null
	,@DEANumber int= null
	,@NARC char(20)= null
	,@Detail char(400)= null
	,@Level char(2)= null
	,@Destination tinyint= null
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	
	
	
	
	Update Forms 
		set 
			CreateUser=@CreateUser, CreateDate=@CreateDate, UnitNumber = @UnitNumber, County = @County
		where
			FormID=@FormID
	
	
	UPDATE dbo.InitialDiagnosis
		set
			Age=@Age, AgeType=@AgeType, Sex=@Sex, AnOX=@AnOX, BGL1=@BLG1, 
			BLG2=@BLG2, BP=@BP, BP2=@BP2, CC=@CC, Category=@Category, 
			Pulse=@Pulse, Pulse2=@Pulse2, Resp=@Resp, Resp2=@Resp2, O2Sat=@O2Sat, 
			O2Sat2=O2Sat2, Loc=@LOC, GCS=@GCS
		where
			FormId=@FormID
	
		
		
	UPDATE dbo.CrashInfo
		set
			Driver_Restrained=@DriverRestrained, Passenger_Restrained=@PassengerRestrained, 
			Speed=@speed, Helmet=@Helmet, Airbag=@Airbag, PKG=@PKG, Rollover = @Rollover,
			Entrapped = @Entrapped, Ejected = @Ejected
		WHERE
			FormId=@FormID
			
		
	
	Update dbo.Alert
		set
			TA=@TraumaAlert, SA=@StrokeAlert, STEMI=@STEMI, TIBR=@TIBR, 
			HX=@History, TX=@Treatment, onset = @Onset, disp = @Dispatcher, 
			ETA = @ETA, Notified = @Notified
		where
			FormId=@FormID
				
	Update MedicalControl
		set
			 Rescue=@Rescue, Meds=@Meds, DrSign=@DrSignature, 
			 DEANumber=@DEANumber, NARC=@NARC
		WHERE
			FormId=@FormID
	
	UPDATE MedicalDetail
		set
			Detail=@Detail, Levels=@Level, Destination=@Destination
		
		
END
GO
/****** Object:  StoredProcedure [dbo].[RunReport]    Script Date: 11/26/2011 14:14:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RunReport]
	@StartDate datetime = null
	,@EndDate datetime = null
	,@Unit int=null
	,@StartAge int =null
	,@EndAge int =null
	,@AgeType int=null
	,@Sex int = null
	,@Category int = null
	,@CC nvarchar(400) = ''
	,@Destination int = null
	,@Level char(2) = NULL
	
AS
BEGIN
	
	select CreateDate, UnitNumber AS UNIT, Age, Sex, Category, CC AS [CC/DESCRIPTION], BP, Pulse as P, Resp AS R, O2Sat AS [O2 SAT], BGL1 AS [BLG#1], Loc AS LOC, GCS AS GCS,
		TA AS [T/A], SA AS [S/A], STEMI AS STEMI, Destination AS [TC/ER/PEDS], Levels AS [LEVEL 1,2,3, T], ETA from vwForms where
		
		CreateDate >= Coalesce(@StartDate, CreateDate)
		and
		CreateDate <=Coalesce(@EndDate, CreateDate)
		and 
		UnitNumber = Coalesce(@Unit, UnitNumber)
		and 
		Age >= Coalesce(@StartAge, Age) 
		and 
		Age<=Coalesce(@EndAge, Age)
		and
		Sex = Coalesce(@Sex, Sex)
		and
		Category LIKE Coalesce(@Category, Category)
		and 
		CC like '%' + @CC + '%'
		and
		Destination = Coalesce(@Destination, Destination)
	
END
GO
/****** Object:  Default [DF_Users_IsActive]    Script Date: 11/26/2011 14:14:46 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  ForeignKey [FK__Alert__FormId__0EA330E9]    Script Date: 11/26/2011 14:14:46 ******/
ALTER TABLE [dbo].[Alert]  WITH CHECK ADD  CONSTRAINT [FK__Alert__FormId__0EA330E9] FOREIGN KEY([FormId])
REFERENCES [dbo].[Forms] ([FormID])
GO
ALTER TABLE [dbo].[Alert] CHECK CONSTRAINT [FK__Alert__FormId__0EA330E9]
GO
/****** Object:  ForeignKey [FK__MVC__FormId__145C0A3F]    Script Date: 11/26/2011 14:14:46 ******/
ALTER TABLE [dbo].[CrashInfo]  WITH CHECK ADD  CONSTRAINT [FK__MVC__FormId__145C0A3F] FOREIGN KEY([FormId])
REFERENCES [dbo].[Forms] ([FormID])
GO
ALTER TABLE [dbo].[CrashInfo] CHECK CONSTRAINT [FK__MVC__FormId__145C0A3F]
GO
/****** Object:  ForeignKey [FK__InitialDi__FormI__117F9D94]    Script Date: 11/26/2011 14:14:46 ******/
ALTER TABLE [dbo].[InitialDiagnosis]  WITH CHECK ADD  CONSTRAINT [FK__InitialDi__FormI__117F9D94] FOREIGN KEY([FormId])
REFERENCES [dbo].[Forms] ([FormID])
GO
ALTER TABLE [dbo].[InitialDiagnosis] CHECK CONSTRAINT [FK__InitialDi__FormI__117F9D94]
GO
/****** Object:  ForeignKey [FK__MedicalCo__FormI__173876EA]    Script Date: 11/26/2011 14:14:46 ******/
ALTER TABLE [dbo].[MedicalControl]  WITH CHECK ADD  CONSTRAINT [FK__MedicalCo__FormI__173876EA] FOREIGN KEY([FormId])
REFERENCES [dbo].[Forms] ([FormID])
GO
ALTER TABLE [dbo].[MedicalControl] CHECK CONSTRAINT [FK__MedicalCo__FormI__173876EA]
GO
/****** Object:  ForeignKey [FK__MedicalDe__FormI__0BC6C43E]    Script Date: 11/26/2011 14:14:46 ******/
ALTER TABLE [dbo].[MedicalDetail]  WITH CHECK ADD  CONSTRAINT [FK__MedicalDe__FormI__0BC6C43E] FOREIGN KEY([FormId])
REFERENCES [dbo].[Forms] ([FormID])
GO
ALTER TABLE [dbo].[MedicalDetail] CHECK CONSTRAINT [FK__MedicalDe__FormI__0BC6C43E]
GO
