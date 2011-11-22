USE [COP4710]
GO
/****** Object:  Table [dbo].[Forms]    Script Date: 11/21/2011 23:25:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Forms](
	[FormID] [int] IDENTITY(1000,1) NOT NULL,
	[CreateUser] [char](20) NULL,
	[CreateDate] [nchar](10) NULL,
	[UnitNumber] [nchar](10) NULL,
 CONSTRAINT [Forms_pk] PRIMARY KEY CLUSTERED 
(
	[FormID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/21/2011 23:25:05 ******/
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
 CONSTRAINT [Users_pk] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 11/21/2011 23:25:06 ******/
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
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 11/21/2011 23:25:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUser]
	@UserID int
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
			UserID = @UserID
	

END
GO
/****** Object:  Table [dbo].[MedicalDetail]    Script Date: 11/21/2011 23:25:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MedicalDetail](
	[FormId] [int] NOT NULL,
	[Detail] [char](400) NULL,
	[Levels] [char](2) NULL,
	[Destination] [tinyint] NULL,
 CONSTRAINT [MedicalDetail_pk] PRIMARY KEY CLUSTERED 
(
	[FormId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MedicalControl]    Script Date: 11/21/2011 23:25:05 ******/
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
	[DrSign] [char](40) NULL,
	[DEANumber] [int] NULL,
	[NARC] [char](20) NULL,
 CONSTRAINT [MedicalControl_pk] PRIMARY KEY CLUSTERED 
(
	[FormId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[ListUsers]    Script Date: 11/21/2011 23:25:06 ******/
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
/****** Object:  StoredProcedure [dbo].[ListForms]    Script Date: 11/21/2011 23:25:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListForms]
	-- Add the parameters for the stored procedure here
	AS
BEGIN
	select * from [Forms]
END
GO
/****** Object:  Table [dbo].[InitialDiagnosis]    Script Date: 11/21/2011 23:25:05 ******/
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
/****** Object:  StoredProcedure [dbo].[GetUserByUsername]    Script Date: 11/21/2011 23:25:06 ******/
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
/****** Object:  Table [dbo].[CrashInfo]    Script Date: 11/21/2011 23:25:05 ******/
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
 CONSTRAINT [MVC_pk] PRIMARY KEY CLUSTERED 
(
	[FormId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Alert]    Script Date: 11/21/2011 23:25:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Alert](
	[FormId] [int] NOT NULL,
	[TA] [char](10) NULL,
	[SA] [char](10) NULL,
	[STEMI] [char](10) NULL,
	[TIBR] [char](10) NULL,
	[HX] [char](10) NULL,
	[TX] [char](10) NULL,
 CONSTRAINT [Alerts_pk] PRIMARY KEY CLUSTERED 
(
	[FormId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[CreateForm]    Script Date: 11/21/2011 23:25:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateForm]
	@CreateUser nvarchar(20)
	,@CreateDate DateTime
	,@UnitNumber int
	,@County tinyint = null
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
	,@TraumaAlert bit= null
	,@StrokeAlert bit= null
	,@Onset time= null
	,@STEMI bit= null
	,@TIBR bit= null
	,@Dispatcher int= null
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
	
	BEGIN
	Insert into Forms ( CreateUser, CreateDate, UnitNumber)
		values
			(@CreateUser, @CreateDate, @UnitNumber)
	END
	
	Set @FormID = SCOPE_IDENTITY()
	
	Insert into dbo.InitialDiagnosis
		( 
		 FormId, Age, AgeType, Sex, AnOX, BGL1, BLG2, BP, BP2, CC, Category, Pulse, Pulse2, Resp, Resp2, O2Sat, O2Sat2, Loc, GCS
		)
	values
		(@FormID, @Age, @AgeType, @Sex, @AnOX, @BLG1, @BLG2, @BP, @BP2, @CC, @Category, @Pulse, @Pulse2, @Resp, @Resp2, @O2Sat, @O2Sat2, @LOC, @GCS)
		
	Insert into dbo.CrashInfo
		(	
			FormId, Driver_Restrained, Passenger_Restrained, Speed, Helmet, Airbag, PKG
		)
	values
		(
			@Formid,@DriverRestrained, @PassengerRestrained, @speed, @Helmet, @Airbag, @PKG
		)
	
	insert into dbo.Alert
		(
			Formid, TA, SA, STEMI, TIBR, HX, TX
		)
	values
		(
			@Formid, @TraumaAlert, @StrokeAlert, @STEMI, @TIBR, @History, @Treatment
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
/****** Object:  Default [DF_Users_IsActive]    Script Date: 11/21/2011 23:25:05 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  ForeignKey [FK__Alert__FormId__0EA330E9]    Script Date: 11/21/2011 23:25:05 ******/
ALTER TABLE [dbo].[Alert]  WITH CHECK ADD  CONSTRAINT [FK__Alert__FormId__0EA330E9] FOREIGN KEY([FormId])
REFERENCES [dbo].[Forms] ([FormID])
GO
ALTER TABLE [dbo].[Alert] CHECK CONSTRAINT [FK__Alert__FormId__0EA330E9]
GO
/****** Object:  ForeignKey [FK__MVC__FormId__145C0A3F]    Script Date: 11/21/2011 23:25:05 ******/
ALTER TABLE [dbo].[CrashInfo]  WITH CHECK ADD  CONSTRAINT [FK__MVC__FormId__145C0A3F] FOREIGN KEY([FormId])
REFERENCES [dbo].[Forms] ([FormID])
GO
ALTER TABLE [dbo].[CrashInfo] CHECK CONSTRAINT [FK__MVC__FormId__145C0A3F]
GO
/****** Object:  ForeignKey [FK__InitialDi__FormI__117F9D94]    Script Date: 11/21/2011 23:25:05 ******/
ALTER TABLE [dbo].[InitialDiagnosis]  WITH CHECK ADD  CONSTRAINT [FK__InitialDi__FormI__117F9D94] FOREIGN KEY([FormId])
REFERENCES [dbo].[Forms] ([FormID])
GO
ALTER TABLE [dbo].[InitialDiagnosis] CHECK CONSTRAINT [FK__InitialDi__FormI__117F9D94]
GO
/****** Object:  ForeignKey [FK__MedicalCo__FormI__173876EA]    Script Date: 11/21/2011 23:25:05 ******/
ALTER TABLE [dbo].[MedicalControl]  WITH CHECK ADD  CONSTRAINT [FK__MedicalCo__FormI__173876EA] FOREIGN KEY([FormId])
REFERENCES [dbo].[Forms] ([FormID])
GO
ALTER TABLE [dbo].[MedicalControl] CHECK CONSTRAINT [FK__MedicalCo__FormI__173876EA]
GO
/****** Object:  ForeignKey [FK__MedicalDe__FormI__0BC6C43E]    Script Date: 11/21/2011 23:25:05 ******/
ALTER TABLE [dbo].[MedicalDetail]  WITH CHECK ADD  CONSTRAINT [FK__MedicalDe__FormI__0BC6C43E] FOREIGN KEY([FormId])
REFERENCES [dbo].[Forms] ([FormID])
GO
ALTER TABLE [dbo].[MedicalDetail] CHECK CONSTRAINT [FK__MedicalDe__FormI__0BC6C43E]
GO
