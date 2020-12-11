/*
 Navicat Premium Data Transfer

 Source Server         : 海看校企
 Source Server Type    : SQL Server
 Source Server Version : 14002027
 Source Host           : 192.168.0.214:1433
 Source Catalog        : HaikanSchoolProjects
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 14002027
 File Encoding         : 65001

 Date: 11/12/2020 10:04:15
*/


-- ----------------------------
-- Table structure for Contract
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Contract]') AND type IN ('U'))
	DROP TABLE [dbo].[Contract]
GO

CREATE TABLE [dbo].[Contract] (
  [CID] int  IDENTITY(1,1) NOT NULL,
  [ProjectID] int  NOT NULL,
  [EnterpriseName] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [ContractName] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [CInformation] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [Note] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [ConsigneeA] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [ConsigneeB] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [LastTime] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [Money] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[Contract] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'合同ID',
'SCHEMA', N'dbo',
'TABLE', N'Contract',
'COLUMN', N'CID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'项目ID',
'SCHEMA', N'dbo',
'TABLE', N'Contract',
'COLUMN', N'ProjectID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'企业名称',
'SCHEMA', N'dbo',
'TABLE', N'Contract',
'COLUMN', N'EnterpriseName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'合同名称',
'SCHEMA', N'dbo',
'TABLE', N'Contract',
'COLUMN', N'ContractName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'签订日期',
'SCHEMA', N'dbo',
'TABLE', N'Contract',
'COLUMN', N'CInformation'
GO

EXEC sp_addextendedproperty
'MS_Description', N'备注',
'SCHEMA', N'dbo',
'TABLE', N'Contract',
'COLUMN', N'Note'
GO

EXEC sp_addextendedproperty
'MS_Description', N'签订人【甲方】',
'SCHEMA', N'dbo',
'TABLE', N'Contract',
'COLUMN', N'ConsigneeA'
GO

EXEC sp_addextendedproperty
'MS_Description', N'签订人【乙方】',
'SCHEMA', N'dbo',
'TABLE', N'Contract',
'COLUMN', N'ConsigneeB'
GO

EXEC sp_addextendedproperty
'MS_Description', N'合同到期时间',
'SCHEMA', N'dbo',
'TABLE', N'Contract',
'COLUMN', N'LastTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'合同金额',
'SCHEMA', N'dbo',
'TABLE', N'Contract',
'COLUMN', N'Money'
GO

EXEC sp_addextendedproperty
'MS_Description', N'合同信息',
'SCHEMA', N'dbo',
'TABLE', N'Contract'
GO


-- ----------------------------
-- Records of Contract
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Contract] ON
GO

INSERT INTO [dbo].[Contract] ([CID], [ProjectID], [EnterpriseName], [ContractName], [CInformation], [Note], [ConsigneeA], [ConsigneeB], [LastTime], [Money]) VALUES (N'4', N'2', N'创维公司', N'合同', N'2014-5-6', N'诶话组', N'汪峰', N'张子琪', N'2018-5-6', N'600000')
GO

INSERT INTO [dbo].[Contract] ([CID], [ProjectID], [EnterpriseName], [ContractName], [CInformation], [Note], [ConsigneeA], [ConsigneeB], [LastTime], [Money]) VALUES (N'5', N'0', N'大河公司', N'合同1', N'2018-07-11', N'ab', N'aa', N'bb', N'2019-5-6', N'632000')
GO

INSERT INTO [dbo].[Contract] ([CID], [ProjectID], [EnterpriseName], [ContractName], [CInformation], [Note], [ConsigneeA], [ConsigneeB], [LastTime], [Money]) VALUES (N'8', N'0', N'新的企业', N'官方', N'2018-07-09', N'华泰股份', N'吧VC下', N'一条', N'2020-9-6', N'254100')
GO

INSERT INTO [dbo].[Contract] ([CID], [ProjectID], [EnterpriseName], [ContractName], [CInformation], [Note], [ConsigneeA], [ConsigneeB], [LastTime], [Money]) VALUES (N'9', N'0', N'新东方', N'rewq', N'2018-07-09', N'fdsa', N'fsda', N'fsda', N'2020-9-6', N'120124')
GO

INSERT INTO [dbo].[Contract] ([CID], [ProjectID], [EnterpriseName], [ContractName], [CInformation], [Note], [ConsigneeA], [ConsigneeB], [LastTime], [Money]) VALUES (N'10', N'0', N'华为', N'h1', N'2018-07-28', N'人群文', N'任发点', N'路过发', N'2020-9-6', N'125421')
GO

INSERT INTO [dbo].[Contract] ([CID], [ProjectID], [EnterpriseName], [ContractName], [CInformation], [Note], [ConsigneeA], [ConsigneeB], [LastTime], [Money]) VALUES (N'11', N'1', N'华为', N'华为订单班', N'2018-08-01', N'', N'华为1', N'华为2', N'2020-9-6', N'212421')
GO

INSERT INTO [dbo].[Contract] ([CID], [ProjectID], [EnterpriseName], [ContractName], [CInformation], [Note], [ConsigneeA], [ConsigneeB], [LastTime], [Money]) VALUES (N'12', N'0', N'阿里巴巴', N'钉钉部署', N'2018-08-01', N'', N'钉钉1', N'钉钉2', N'2020-9-6', N'145453')
GO

INSERT INTO [dbo].[Contract] ([CID], [ProjectID], [EnterpriseName], [ContractName], [CInformation], [Note], [ConsigneeA], [ConsigneeB], [LastTime], [Money]) VALUES (N'14', N'0', N'新的企业', N'店铺销售', N'2018-08-01', N'', N'A', N'B', N'2020-9-6', N'444144')
GO

INSERT INTO [dbo].[Contract] ([CID], [ProjectID], [EnterpriseName], [ContractName], [CInformation], [Note], [ConsigneeA], [ConsigneeB], [LastTime], [Money]) VALUES (N'15', N'0', N'阿里巴巴', N'二手车', N'2018-08-01', N'', N'A', N'B', N'2020-09-06', N'215415')
GO

INSERT INTO [dbo].[Contract] ([CID], [ProjectID], [EnterpriseName], [ContractName], [CInformation], [Note], [ConsigneeA], [ConsigneeB], [LastTime], [Money]) VALUES (N'16', N'0', N'创维公司', N'BB', N'2018-08-01', N'', N'A', N'A', N'2020-09-06', N'101013')
GO

SET IDENTITY_INSERT [dbo].[Contract] OFF
GO


-- ----------------------------
-- Table structure for Department
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Department]') AND type IN ('U'))
	DROP TABLE [dbo].[Department]
GO

CREATE TABLE [dbo].[Department] (
  [ID] int  IDENTITY(1,1) NOT NULL,
  [DepartmentName] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [ChargeMan] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Tel] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [Fax] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [details] varchar(8000) COLLATE Chinese_PRC_CI_AS  NULL,
  [IsDelete] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[Department] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'院系名称',
'SCHEMA', N'dbo',
'TABLE', N'Department',
'COLUMN', N'DepartmentName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'责任人',
'SCHEMA', N'dbo',
'TABLE', N'Department',
'COLUMN', N'ChargeMan'
GO

EXEC sp_addextendedproperty
'MS_Description', N'电话',
'SCHEMA', N'dbo',
'TABLE', N'Department',
'COLUMN', N'Tel'
GO

EXEC sp_addextendedproperty
'MS_Description', N'传真',
'SCHEMA', N'dbo',
'TABLE', N'Department',
'COLUMN', N'Fax'
GO

EXEC sp_addextendedproperty
'MS_Description', N'院系详情',
'SCHEMA', N'dbo',
'TABLE', N'Department',
'COLUMN', N'details'
GO

EXEC sp_addextendedproperty
'MS_Description', N'所属学院',
'SCHEMA', N'dbo',
'TABLE', N'Department'
GO


-- ----------------------------
-- Table structure for Eenterprises
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Eenterprises]') AND type IN ('U'))
	DROP TABLE [dbo].[Eenterprises]
GO

CREATE TABLE [dbo].[Eenterprises] (
  [EnterpriseID] int  IDENTITY(1,1) NOT NULL,
  [EnterpriseName] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [Contact] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [EInformation] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [Note] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [Audit] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[Eenterprises] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'企业ID',
'SCHEMA', N'dbo',
'TABLE', N'Eenterprises',
'COLUMN', N'EnterpriseID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'企业名称',
'SCHEMA', N'dbo',
'TABLE', N'Eenterprises',
'COLUMN', N'EnterpriseName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'联系方式',
'SCHEMA', N'dbo',
'TABLE', N'Eenterprises',
'COLUMN', N'Contact'
GO

EXEC sp_addextendedproperty
'MS_Description', N'企业资料信息【停用】',
'SCHEMA', N'dbo',
'TABLE', N'Eenterprises',
'COLUMN', N'EInformation'
GO

EXEC sp_addextendedproperty
'MS_Description', N'备注',
'SCHEMA', N'dbo',
'TABLE', N'Eenterprises',
'COLUMN', N'Note'
GO

EXEC sp_addextendedproperty
'MS_Description', N'审核状态【只有院系领导及以上可以审核】',
'SCHEMA', N'dbo',
'TABLE', N'Eenterprises',
'COLUMN', N'Audit'
GO

EXEC sp_addextendedproperty
'MS_Description', N'企业信息',
'SCHEMA', N'dbo',
'TABLE', N'Eenterprises'
GO


-- ----------------------------
-- Records of Eenterprises
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Eenterprises] ON
GO

INSERT INTO [dbo].[Eenterprises] ([EnterpriseID], [EnterpriseName], [Contact], [EInformation], [Note], [Audit]) VALUES (N'2', N'大江公司', N'1365214441', NULL, N'拿来的', N'已通过')
GO

INSERT INTO [dbo].[Eenterprises] ([EnterpriseID], [EnterpriseName], [Contact], [EInformation], [Note], [Audit]) VALUES (N'3', N'新东方', N'1326554', NULL, N'进而服ID是', N'待审核')
GO

INSERT INTO [dbo].[Eenterprises] ([EnterpriseID], [EnterpriseName], [Contact], [EInformation], [Note], [Audit]) VALUES (N'5', N'新的企业', N'13652441', NULL, N'新的', N'已通过')
GO

INSERT INTO [dbo].[Eenterprises] ([EnterpriseID], [EnterpriseName], [Contact], [EInformation], [Note], [Audit]) VALUES (N'6', N'华为', N'13652653254', NULL, N'画的', N'已通过')
GO

INSERT INTO [dbo].[Eenterprises] ([EnterpriseID], [EnterpriseName], [Contact], [EInformation], [Note], [Audit]) VALUES (N'12', N'创维公司', N'03215-652', NULL, N'奋斗', N'已通过')
GO

INSERT INTO [dbo].[Eenterprises] ([EnterpriseID], [EnterpriseName], [Contact], [EInformation], [Note], [Audit]) VALUES (N'13', N'网易云大公司', N'850236', NULL, N'刚入住不久', N'审核中')
GO

INSERT INTO [dbo].[Eenterprises] ([EnterpriseID], [EnterpriseName], [Contact], [EInformation], [Note], [Audit]) VALUES (N'18', N'德邦物流', N'98525-652144', NULL, N'德邦产业', N'待审核')
GO

SET IDENTITY_INSERT [dbo].[Eenterprises] OFF
GO


-- ----------------------------
-- Table structure for Employee
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee]') AND type IN ('U'))
	DROP TABLE [dbo].[Employee]
GO

CREATE TABLE [dbo].[Employee] (
  [EID] int  IDENTITY(1,1) NOT NULL,
  [ProjectName] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [EnterpriseName] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [EmployeeName] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [EmployeeTime] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [Note] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[Employee] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'人员ID',
'SCHEMA', N'dbo',
'TABLE', N'Employee',
'COLUMN', N'EID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'项目名称',
'SCHEMA', N'dbo',
'TABLE', N'Employee',
'COLUMN', N'ProjectName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'企业名称',
'SCHEMA', N'dbo',
'TABLE', N'Employee',
'COLUMN', N'EnterpriseName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'员工姓名',
'SCHEMA', N'dbo',
'TABLE', N'Employee',
'COLUMN', N'EmployeeName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'工作时长',
'SCHEMA', N'dbo',
'TABLE', N'Employee',
'COLUMN', N'EmployeeTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'备注',
'SCHEMA', N'dbo',
'TABLE', N'Employee',
'COLUMN', N'Note'
GO

EXEC sp_addextendedproperty
'MS_Description', N'员工信息',
'SCHEMA', N'dbo',
'TABLE', N'Employee'
GO


-- ----------------------------
-- Records of Employee
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Employee] ON
GO

INSERT INTO [dbo].[Employee] ([EID], [ProjectName], [EnterpriseName], [EmployeeName], [EmployeeTime], [Note]) VALUES (N'1', N'安保责任系统', N'华为', N'韩国', N'500', N'范德萨')
GO

INSERT INTO [dbo].[Employee] ([EID], [ProjectName], [EnterpriseName], [EmployeeName], [EmployeeTime], [Note]) VALUES (N'2', N'哈喽', N'范德萨', N'张飞', N'804', N'工作了80天')
GO

INSERT INTO [dbo].[Employee] ([EID], [ProjectName], [EnterpriseName], [EmployeeName], [EmployeeTime], [Note]) VALUES (N'3', N'雷u', N'新的企业', N'kuie', N'563', N'工作了563天')
GO

INSERT INTO [dbo].[Employee] ([EID], [ProjectName], [EnterpriseName], [EmployeeName], [EmployeeTime], [Note]) VALUES (N'5', N'大江ERP管理系统', N'大江公司', N'jaf', N'800', N'')
GO

INSERT INTO [dbo].[Employee] ([EID], [ProjectName], [EnterpriseName], [EmployeeName], [EmployeeTime], [Note]) VALUES (N'6', N'', N'新的企业', N'华威', N'333', N'老员工')
GO

SET IDENTITY_INSERT [dbo].[Employee] OFF
GO


-- ----------------------------
-- Table structure for Financial
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Financial]') AND type IN ('U'))
	DROP TABLE [dbo].[Financial]
GO

CREATE TABLE [dbo].[Financial] (
  [FID] int  IDENTITY(1,1) NOT NULL,
  [ProjectName] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [EnterpriseName] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [IsPay] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [SuccessfulTime] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [Person] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [PayMoney] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [SystemUser] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [TimeStr] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [Note] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[Financial] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'财务ID',
'SCHEMA', N'dbo',
'TABLE', N'Financial',
'COLUMN', N'FID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'项目名称',
'SCHEMA', N'dbo',
'TABLE', N'Financial',
'COLUMN', N'ProjectName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'企业名称',
'SCHEMA', N'dbo',
'TABLE', N'Financial',
'COLUMN', N'EnterpriseName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'收款还是付款',
'SCHEMA', N'dbo',
'TABLE', N'Financial',
'COLUMN', N'IsPay'
GO

EXEC sp_addextendedproperty
'MS_Description', N'成交时间',
'SCHEMA', N'dbo',
'TABLE', N'Financial',
'COLUMN', N'SuccessfulTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'收款/付款人',
'SCHEMA', N'dbo',
'TABLE', N'Financial',
'COLUMN', N'Person'
GO

EXEC sp_addextendedproperty
'MS_Description', N'付款/收款金额',
'SCHEMA', N'dbo',
'TABLE', N'Financial',
'COLUMN', N'PayMoney'
GO

EXEC sp_addextendedproperty
'MS_Description', N'操作管理员名称',
'SCHEMA', N'dbo',
'TABLE', N'Financial',
'COLUMN', N'SystemUser'
GO

EXEC sp_addextendedproperty
'MS_Description', N'记录时间',
'SCHEMA', N'dbo',
'TABLE', N'Financial',
'COLUMN', N'TimeStr'
GO

EXEC sp_addextendedproperty
'MS_Description', N'备注【付清/未付清】',
'SCHEMA', N'dbo',
'TABLE', N'Financial',
'COLUMN', N'Note'
GO

EXEC sp_addextendedproperty
'MS_Description', N'财务信息',
'SCHEMA', N'dbo',
'TABLE', N'Financial'
GO


-- ----------------------------
-- Records of Financial
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Financial] ON
GO

INSERT INTO [dbo].[Financial] ([FID], [ProjectName], [EnterpriseName], [IsPay], [SuccessfulTime], [Person], [PayMoney], [SystemUser], [TimeStr], [Note]) VALUES (N'3', N'安保责任系统', N'华为', N'收款', N'2018-9-6', N'张明', N'900', N'admin', N'2018-7-30', N'已收到部分款项')
GO

INSERT INTO [dbo].[Financial] ([FID], [ProjectName], [EnterpriseName], [IsPay], [SuccessfulTime], [Person], [PayMoney], [SystemUser], [TimeStr], [Note]) VALUES (N'4', N'emui智能系统', N'华为', N'收款', N'2018-07-30', N'咋发', N'9000', N'admin', N'2018 - 08 - 03 09: 46:01', N'雷U系列')
GO

INSERT INTO [dbo].[Financial] ([FID], [ProjectName], [EnterpriseName], [IsPay], [SuccessfulTime], [Person], [PayMoney], [SystemUser], [TimeStr], [Note]) VALUES (N'6', N'emui智能系统', N'华为', N'付款', N'2018-08-01', N'乔治', N'54646', N'admin', N'2018 - 08 - 01 17: 49:23', N'666')
GO

INSERT INTO [dbo].[Financial] ([FID], [ProjectName], [EnterpriseName], [IsPay], [SuccessfulTime], [Person], [PayMoney], [SystemUser], [TimeStr], [Note]) VALUES (N'7', N'emui智能系统', N'创维公司', N'付款', N'2018-08-01', N'曹德圣', N'42448', N'admin', N'2018 - 08 - 04 08: 50:50', N'6')
GO

SET IDENTITY_INSERT [dbo].[Financial] OFF
GO


-- ----------------------------
-- Table structure for HFile
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[HFile]') AND type IN ('U'))
	DROP TABLE [dbo].[HFile]
GO

CREATE TABLE [dbo].[HFile] (
  [FileID] int  IDENTITY(1,1) NOT NULL,
  [EnterpriseName] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [EnterpriseFile] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [ContractFile] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [InvoiceFile] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [ProjectFile] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [IsDele] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[HFile] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'文件ID',
'SCHEMA', N'dbo',
'TABLE', N'HFile',
'COLUMN', N'FileID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'企业名称',
'SCHEMA', N'dbo',
'TABLE', N'HFile',
'COLUMN', N'EnterpriseName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'企业文件',
'SCHEMA', N'dbo',
'TABLE', N'HFile',
'COLUMN', N'EnterpriseFile'
GO

EXEC sp_addextendedproperty
'MS_Description', N'合同文件',
'SCHEMA', N'dbo',
'TABLE', N'HFile',
'COLUMN', N'ContractFile'
GO

EXEC sp_addextendedproperty
'MS_Description', N'发票文件',
'SCHEMA', N'dbo',
'TABLE', N'HFile',
'COLUMN', N'InvoiceFile'
GO

EXEC sp_addextendedproperty
'MS_Description', N'项目资料',
'SCHEMA', N'dbo',
'TABLE', N'HFile',
'COLUMN', N'ProjectFile'
GO

EXEC sp_addextendedproperty
'MS_Description', N'删除记录',
'SCHEMA', N'dbo',
'TABLE', N'HFile',
'COLUMN', N'IsDele'
GO

EXEC sp_addextendedproperty
'MS_Description', N'文件资料',
'SCHEMA', N'dbo',
'TABLE', N'HFile'
GO


-- ----------------------------
-- Records of HFile
-- ----------------------------
SET IDENTITY_INSERT [dbo].[HFile] ON
GO

INSERT INTO [dbo].[HFile] ([FileID], [EnterpriseName], [EnterpriseFile], [ContractFile], [InvoiceFile], [ProjectFile], [IsDele]) VALUES (N'1', N'创维公司', N'aaa.zip', N'合同1', N'发票1', NULL, N'0')
GO

INSERT INTO [dbo].[HFile] ([FileID], [EnterpriseName], [EnterpriseFile], [ContractFile], [InvoiceFile], [ProjectFile], [IsDele]) VALUES (N'16', N'新东方', N'', N'normnfkc2288adc6.nlp', N'normnfkde64bff71.nlp', NULL, N'0')
GO

INSERT INTO [dbo].[HFile] ([FileID], [EnterpriseName], [EnterpriseFile], [ContractFile], [InvoiceFile], [ProjectFile], [IsDele]) VALUES (N'17', N'范德萨', N'sorttbls9a942898.nlp', N'normnfkcc7e92a4e.nlp', N'normnfkd95c81481.nlp', NULL, N'0')
GO

INSERT INTO [dbo].[HFile] ([FileID], [EnterpriseName], [EnterpriseFile], [ContractFile], [InvoiceFile], [ProjectFile], [IsDele]) VALUES (N'18', N'新东方', N'', N'', N'', N'xjis46b7ecee.nlp', N'0')
GO

INSERT INTO [dbo].[HFile] ([FileID], [EnterpriseName], [EnterpriseFile], [ContractFile], [InvoiceFile], [ProjectFile], [IsDele]) VALUES (N'19', N'新的企业', N'prc498a5206.nlp', N'normnfd191b810a.nlp', N'xjis4c5d0005.nlp', N'ksc9f882e0e.nlp', N'0')
GO

INSERT INTO [dbo].[HFile] ([FileID], [EnterpriseName], [EnterpriseFile], [ContractFile], [InvoiceFile], [ProjectFile], [IsDele]) VALUES (N'20', N'创维公司', N'使用说明f5ed8da3.txt', N'使用说明7455f623.txt', N'', N'', N'1')
GO

INSERT INTO [dbo].[HFile] ([FileID], [EnterpriseName], [EnterpriseFile], [ContractFile], [InvoiceFile], [ProjectFile], [IsDele]) VALUES (N'21', N'创维公司', N'_代码文件说明9f32291f.docx', N'_代码文件说明6feccee4.docx', N'校企合作9d35c323.docx', N'_代码文件说明0eccf8ac.docx', N'1')
GO

INSERT INTO [dbo].[HFile] ([FileID], [EnterpriseName], [EnterpriseFile], [ContractFile], [InvoiceFile], [ProjectFile], [IsDele]) VALUES (N'22', N'华为', N'校企合作dedb5448.docx', N'校企合作ed6de956.docx', N'校企合作bb12659c.docx', N'新建 Microsoft Word 文档e8d865e4.docx', N'1')
GO

INSERT INTO [dbo].[HFile] ([FileID], [EnterpriseName], [EnterpriseFile], [ContractFile], [InvoiceFile], [ProjectFile], [IsDele]) VALUES (N'23', N'阿里巴巴', N'总体设计计划表b38863af.doc', N'', N'', N'', N'0')
GO

INSERT INTO [dbo].[HFile] ([FileID], [EnterpriseName], [EnterpriseFile], [ContractFile], [InvoiceFile], [ProjectFile], [IsDele]) VALUES (N'24', N'阿里巴巴', N'校企合作7feaa410.docx', N'', N'', N'', N'0')
GO

INSERT INTO [dbo].[HFile] ([FileID], [EnterpriseName], [EnterpriseFile], [ContractFile], [InvoiceFile], [ProjectFile], [IsDele]) VALUES (N'25', N'阿里巴巴', N'校企合作管理系统测试计划表bd078948.doc', N'', N'', N'', N'0')
GO

INSERT INTO [dbo].[HFile] ([FileID], [EnterpriseName], [EnterpriseFile], [ContractFile], [InvoiceFile], [ProjectFile], [IsDele]) VALUES (N'26', N'阿里巴巴', N'', N'', N'', N'', N'0')
GO

INSERT INTO [dbo].[HFile] ([FileID], [EnterpriseName], [EnterpriseFile], [ContractFile], [InvoiceFile], [ProjectFile], [IsDele]) VALUES (N'27', N'阿里巴巴', N'', N'', N'', N'', N'0')
GO

INSERT INTO [dbo].[HFile] ([FileID], [EnterpriseName], [EnterpriseFile], [ContractFile], [InvoiceFile], [ProjectFile], [IsDele]) VALUES (N'28', N'德旺3', N'', N'', N'', N'', N'0')
GO

INSERT INTO [dbo].[HFile] ([FileID], [EnterpriseName], [EnterpriseFile], [ContractFile], [InvoiceFile], [ProjectFile], [IsDele]) VALUES (N'29', N'新的企业', N'', N'', N'', N'', N'0')
GO

SET IDENTITY_INSERT [dbo].[HFile] OFF
GO


-- ----------------------------
-- Table structure for Invoice
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Invoice]') AND type IN ('U'))
	DROP TABLE [dbo].[Invoice]
GO

CREATE TABLE [dbo].[Invoice] (
  [ProjectName] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [EnterpriseName] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [InvoiceID] int  IDENTITY(1,1) NOT NULL,
  [InvoiceName] varchar(20) COLLATE Chinese_PRC_CI_AS  NULL,
  [InvoiceTime] varchar(20) COLLATE Chinese_PRC_CI_AS  NULL,
  [Note] varchar(20) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[Invoice] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'项目名称',
'SCHEMA', N'dbo',
'TABLE', N'Invoice',
'COLUMN', N'ProjectName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'企业名称',
'SCHEMA', N'dbo',
'TABLE', N'Invoice',
'COLUMN', N'EnterpriseName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'发票ID',
'SCHEMA', N'dbo',
'TABLE', N'Invoice',
'COLUMN', N'InvoiceID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'发票名称',
'SCHEMA', N'dbo',
'TABLE', N'Invoice',
'COLUMN', N'InvoiceName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'发票录入时间',
'SCHEMA', N'dbo',
'TABLE', N'Invoice',
'COLUMN', N'InvoiceTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'备注',
'SCHEMA', N'dbo',
'TABLE', N'Invoice',
'COLUMN', N'Note'
GO

EXEC sp_addextendedproperty
'MS_Description', N'发票信息',
'SCHEMA', N'dbo',
'TABLE', N'Invoice'
GO


-- ----------------------------
-- Records of Invoice
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Invoice] ON
GO

INSERT INTO [dbo].[Invoice] ([ProjectName], [EnterpriseName], [InvoiceID], [InvoiceName], [InvoiceTime], [Note]) VALUES (N'安保责任系统', N'华为', N'1', N'安保发票', N'2018-8-1', N'发票')
GO

SET IDENTITY_INSERT [dbo].[Invoice] OFF
GO


-- ----------------------------
-- Table structure for Project
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Project]') AND type IN ('U'))
	DROP TABLE [dbo].[Project]
GO

CREATE TABLE [dbo].[Project] (
  [EnterpriseName] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [ProjectID] int  IDENTITY(1,1) NOT NULL,
  [ProjectName] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [Projectstatus] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [DName] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [PersonInCharge] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [ProjectData] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [Note] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL,
  [addTime] varchar(255) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[Project] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'企业名称',
'SCHEMA', N'dbo',
'TABLE', N'Project',
'COLUMN', N'EnterpriseName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'ID',
'SCHEMA', N'dbo',
'TABLE', N'Project',
'COLUMN', N'ProjectID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'项目名称',
'SCHEMA', N'dbo',
'TABLE', N'Project',
'COLUMN', N'ProjectName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'项目状态【开发中，维护中】',
'SCHEMA', N'dbo',
'TABLE', N'Project',
'COLUMN', N'Projectstatus'
GO

EXEC sp_addextendedproperty
'MS_Description', N'用户引进【那个用户角色引进来的项目】',
'SCHEMA', N'dbo',
'TABLE', N'Project',
'COLUMN', N'DName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'主要负责人',
'SCHEMA', N'dbo',
'TABLE', N'Project',
'COLUMN', N'PersonInCharge'
GO

EXEC sp_addextendedproperty
'MS_Description', N'项目资料（存放文件地址）【停用】',
'SCHEMA', N'dbo',
'TABLE', N'Project',
'COLUMN', N'ProjectData'
GO

EXEC sp_addextendedproperty
'MS_Description', N'备注',
'SCHEMA', N'dbo',
'TABLE', N'Project',
'COLUMN', N'Note'
GO

EXEC sp_addextendedproperty
'MS_Description', N'项目添加时间',
'SCHEMA', N'dbo',
'TABLE', N'Project',
'COLUMN', N'addTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'项目信息',
'SCHEMA', N'dbo',
'TABLE', N'Project'
GO


-- ----------------------------
-- Records of Project
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Project] ON
GO

INSERT INTO [dbo].[Project] ([EnterpriseName], [ProjectID], [ProjectName], [Projectstatus], [DName], [PersonInCharge], [ProjectData], [Note], [addTime]) VALUES (N'华为', N'1', N'安保责任系统', N'开发中', N'校领导', N'成孔', N'aaa', NULL, N'2017-07-24 17:02:31')
GO

INSERT INTO [dbo].[Project] ([EnterpriseName], [ProjectID], [ProjectName], [Projectstatus], [DName], [PersonInCharge], [ProjectData], [Note], [addTime]) VALUES (N'新的企业', N'2', N'哈喽', N'维护中', N'系统管理员', N'于夫', NULL, N'2015656的上市', N'2016-07-24 17:02:31')
GO

INSERT INTO [dbo].[Project] ([EnterpriseName], [ProjectID], [ProjectName], [Projectstatus], [DName], [PersonInCharge], [ProjectData], [Note], [addTime]) VALUES (N'创维公司', N'4', N'雷u', N'测试中', N'系统管理员', N'雷', NULL, N'雷', N'2015-07-24 17:02:31')
GO

INSERT INTO [dbo].[Project] ([EnterpriseName], [ProjectID], [ProjectName], [Projectstatus], [DName], [PersonInCharge], [ProjectData], [Note], [addTime]) VALUES (N'大江公司', N'5', N'大江ERP管理系统', N'开发中', N'系统管理员', N'姜子豪', NULL, N'2018年开发', N'2018-07-24 17:02:31')
GO

INSERT INTO [dbo].[Project] ([EnterpriseName], [ProjectID], [ProjectName], [Projectstatus], [DName], [PersonInCharge], [ProjectData], [Note], [addTime]) VALUES (N'阿里巴巴', N'6', N'emui智能系统', N'开发中', N'系统管理员', N'张飞4', NULL, N'2018-2019', NULL)
GO

INSERT INTO [dbo].[Project] ([EnterpriseName], [ProjectID], [ProjectName], [Projectstatus], [DName], [PersonInCharge], [ProjectData], [Note], [addTime]) VALUES (N'华为', N'7', N'吃饭', N'维护中', N'系统管理员', N'我', NULL, N'我', NULL)
GO

INSERT INTO [dbo].[Project] ([EnterpriseName], [ProjectID], [ProjectName], [Projectstatus], [DName], [PersonInCharge], [ProjectData], [Note], [addTime]) VALUES (N'阿里巴巴', N'9', N'淘宝部署', N'维护中', N'系统管理员', N'罗志祥', NULL, N'早日收购', NULL)
GO

SET IDENTITY_INSERT [dbo].[Project] OFF
GO


-- ----------------------------
-- Table structure for SystemLog
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SystemLog]') AND type IN ('U'))
	DROP TABLE [dbo].[SystemLog]
GO

CREATE TABLE [dbo].[SystemLog] (
  [ID] int  IDENTITY(1,1) NOT NULL,
  [UserName] varchar(100) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [TimeStr] datetime2(7)  NOT NULL,
  [ActionStr] varchar(max) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [IPAddress] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [Type] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [AddTime] datetime2(7)  NOT NULL,
  [AddPeople] varchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[SystemLog] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'操作用户',
'SCHEMA', N'dbo',
'TABLE', N'SystemLog',
'COLUMN', N'UserName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'操作时间',
'SCHEMA', N'dbo',
'TABLE', N'SystemLog',
'COLUMN', N'TimeStr'
GO

EXEC sp_addextendedproperty
'MS_Description', N'操作内容',
'SCHEMA', N'dbo',
'TABLE', N'SystemLog',
'COLUMN', N'ActionStr'
GO

EXEC sp_addextendedproperty
'MS_Description', N'IP地址',
'SCHEMA', N'dbo',
'TABLE', N'SystemLog',
'COLUMN', N'IPAddress'
GO

EXEC sp_addextendedproperty
'MS_Description', N'操作类型（增删改查）',
'SCHEMA', N'dbo',
'TABLE', N'SystemLog',
'COLUMN', N'Type'
GO

EXEC sp_addextendedproperty
'MS_Description', N'添加时间',
'SCHEMA', N'dbo',
'TABLE', N'SystemLog',
'COLUMN', N'AddTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'添加人',
'SCHEMA', N'dbo',
'TABLE', N'SystemLog',
'COLUMN', N'AddPeople'
GO

EXEC sp_addextendedproperty
'MS_Description', N'系统日志表',
'SCHEMA', N'dbo',
'TABLE', N'SystemLog'
GO


-- ----------------------------
-- Records of SystemLog
-- ----------------------------
SET IDENTITY_INSERT [dbo].[SystemLog] ON
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'2', N'admin', N'2018-07-24 17:02:31.0000000', N'用户登陆成功', N'::1', N'登陆', N'2018-07-24 17:02:31.0000000', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'6', N'admin', N'2020-11-12 20:12:50.9286497', N'用户修改菜单信息', N'127.0.0.1', N'修改', N'2020-11-12 20:12:50.9286497', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'7', N'admin', N'2020-11-12 20:13:11.8624442', N'用户修改菜单信息', N'127.0.0.1', N'修改', N'2020-11-12 20:13:11.8624442', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'8', N'admin', N'2020-11-12 20:22:14.8059509', N'查看用户列表', N'::1', N'查询', N'2020-11-12 20:22:14.8059509', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'9', N'admin', N'2020-11-12 20:29:13.7524286', N'查看用户列表', N'::1', N'查询', N'2020-11-12 20:29:13.7534258', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'10', N'admin', N'2020-11-12 20:29:13.7733726', N'用户查看管理员列表', N'::1', N'查看', N'2020-11-12 20:29:13.7733726', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'11', N'admin', N'2020-11-13 08:39:43.9958309', N'用户修改菜单信息', N'::1', N'修改', N'2020-11-13 08:39:43.9958309', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'12', N'admin', N'2020-11-13 08:39:47.0532250', N'查看用户列表', N'::1', N'查询', N'2020-11-13 08:39:47.0532250', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'13', N'admin', N'2020-11-13 08:40:10.6531199', N'用户修改角色信息，角色名为：学校领导，权限字符串为：|EP||EnterpriseShow||EnterpriseList||Enterprise||EnterpriseAdd||EnterpriseModify||EnterpriseDel||EnterpriseImport||EnterpriseExport||EnterpriseAllShow||EP||ContractShow||ContractList||Contract||ContractAdd||ContractModify||ContractDel||ContractImport||ContractExport||ContractAllShow||EP||ProjectShow||ProjectList||Project||ProjectAdd||ProjectModify||ProjectDel||ProjectImport||ProjectExport||ProjectAllShow||JS||FinancialShow||FinancialList||Financial||FinancialAdd||FinancialModify||FinancialDel||FinancialImport||FinancialExport||FinancialAllShow||JS||EmployeeShow||EmployeeList||Employee||EmployeeAdd||EmployeeModify||EmployeeDel||EmployeeImport||EmployeeExport||EmployeeAllShow||SYSTEM||SystemUserShow||SystemUserList||SystemUser||SystemUserAdd||SystemUserModify||SystemUserDel||SystemUserImport||SystemUserExport||SystemUserAllShow||SYSTEM||SystemSettingShow||SystemSettingList||SystemSetting||SystemSettingAdd||SystemSettingModify||SystemSettingDel||SystemSettingImport||SystemSettingExport||SystemSettingAllShow||SYSTEM||SystemLogShow||SystemLogList||SystemLog||SystemLogAdd||SystemLogModify||SystemLogDel||SystemLogImport||SystemLogExport||SystemLogAllShow||SYSTEM||SystemMenuShow||SystemMenuList||SystemMenu||SystemMenuAdd||SystemMenuModify||SystemMenuDel||SystemMenuImport||SystemMenuExport||SystemMenuAllShow||SYSTEM||SystemRolesShow||SystemRolesList||SystemRoles||SystemRolesAdd||SystemRolesModify||SystemRolesDel||SystemRolesImport||SystemRolesExport||SystemRolesAllShow||TJFX||XmkfFXShow||XmkfFXList||XmkfFX||XmkfFXAdd||XmkfFXModify||XmkfFXDel||XmkfFXImport||XmkfFXExport||XmkfFXAllShow||TJFX||XmpersonFXShow||XmpersonFXList||XmpersonFX||XmpersonFXAdd||XmpersonFXModify||XmpersonFXDel||XmpersonFXImport||XmpersonFXExport||XmpersonFXAllShow||TJFX||personFXShow||personFXList||personFX||personFXAdd||personFXModify||personFXDel||personFXImport||personFXExport||personFXAllShow||TJFX||FinancialFXShow||FinancialFXList||FinancialFX||FinancialFXAdd||FinancialFXModify||FinancialFXDel||FinancialFXImport||FinancialFXExport||FinancialFXAllShow|', N'::1', N'修改', N'2020-11-13 08:40:10.6531199', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'14', N'admin', N'2020-11-13 08:40:18.8194957', N'查看用户列表', N'::1', N'查询', N'2020-11-13 08:40:18.8194957', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'15', N'admin', N'2020-11-13 08:40:18.8344516', N'用户查看管理员列表', N'::1', N'查看', N'2020-11-13 08:40:18.8344516', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'16', N'admin', N'2020-11-13 08:40:37.6019725', N'查看用户列表', N'::1', N'查询', N'2020-11-13 08:40:37.6019725', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'17', N'admin', N'2020-11-13 08:40:37.6130019', N'用户查看管理员列表', N'::1', N'查看', N'2020-11-13 08:40:37.6130019', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'21', N'admin', N'2020-11-13 08:49:04.8566633', N'查看用户列表', N'::1', N'查询', N'2020-11-13 08:49:04.8566633', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'22', N'admin', N'2020-11-13 08:49:10.2077116', N'查看用户列表', N'::1', N'查询', N'2020-11-13 08:49:10.2077116', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'23', N'admin', N'2020-11-13 08:49:10.2196796', N'用户查看管理员列表', N'::1', N'查看', N'2020-11-13 08:49:10.2196796', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'29', N'admin', N'2020-11-13 15:31:27.3463818', N'查看用户列表', N'::1', N'查询', N'2020-11-13 15:31:27.3463818', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'30', N'admin', N'2020-11-13 15:31:33.8636680', N'查看用户列表', N'::1', N'查询', N'2020-11-13 15:31:33.8636680', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'31', N'admin', N'2020-11-13 15:31:33.8816202', N'用户查看管理员列表', N'::1', N'查看', N'2020-11-13 15:31:33.8816202', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'32', N'admin', N'2020-11-13 16:02:55.7648394', N'查看用户列表', N'::1', N'查询', N'2020-11-13 16:02:55.7658370', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'33', N'admin', N'2020-11-13 16:02:55.7798298', N'用户查看管理员列表', N'::1', N'查看', N'2020-11-13 16:02:55.7798298', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'34', N'admin', N'2020-11-13 17:20:06.8565841', N'查看用户列表', N'::1', N'查询', N'2020-11-13 17:20:06.8565841', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'35', N'admin', N'2020-11-13 17:20:11.8400110', N'查看用户列表', N'::1', N'查询', N'2020-11-13 17:20:11.8400110', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'36', N'admin', N'2020-11-13 17:20:11.8519506', N'用户查看管理员列表', N'::1', N'查看', N'2020-11-13 17:20:11.8519506', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'38', N'admin', N'2020-11-13 18:34:32.3914893', N'查看用户列表', N'::1', N'查询', N'2020-11-13 18:34:32.3914893', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'39', N'admin', N'2020-11-13 18:34:38.0552831', N'查看用户列表', N'::1', N'查询', N'2020-11-13 18:34:38.0552831', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'40', N'admin', N'2020-11-13 18:34:38.0662529', N'用户查看管理员列表', N'::1', N'查看', N'2020-11-13 18:34:38.0662529', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'41', N'admin', N'2020-11-13 18:39:55.8060456', N'查看用户列表', N'::1', N'查询', N'2020-11-13 18:39:55.8060456', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'42', N'admin', N'2020-11-13 18:40:01.5140047', N'查看用户列表', N'::1', N'查询', N'2020-11-13 18:40:01.5140047', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'43', N'admin', N'2020-11-13 18:40:01.5249696', N'用户查看管理员列表', N'::1', N'查看', N'2020-11-13 18:40:01.5249696', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'44', N'admin', N'2020-11-13 19:28:18.8267073', N'查看用户列表', N'::1', N'查询', N'2020-11-13 19:28:18.8267073', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'45', N'admin', N'2020-11-13 19:28:23.4334642', N'查看用户列表', N'::1', N'查询', N'2020-11-13 19:28:23.4334642', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'46', N'admin', N'2020-11-13 19:28:23.4444065', N'用户查看管理员列表', N'::1', N'查看', N'2020-11-13 19:28:23.4444065', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'18', N'admin', N'2020-11-13 08:45:24.0132105', N'查看用户列表', N'::1', N'查询', N'2020-11-13 08:45:24.0132105', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'19', N'admin', N'2020-11-13 08:45:29.0081726', N'查看用户列表', N'::1', N'查询', N'2020-11-13 08:45:29.0081726', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'20', N'admin', N'2020-11-13 08:45:29.0191419', N'用户查看管理员列表', N'::1', N'查看', N'2020-11-13 08:45:29.0191419', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'24', N'admin', N'2020-11-13 10:56:17.1312441', N'查看用户列表', N'::1', N'查询', N'2020-11-13 10:56:17.1322407', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'25', N'admin', N'2020-11-13 10:56:31.4334115', N'查看用户列表', N'::1', N'查询', N'2020-11-13 10:56:31.4334115', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'26', N'admin', N'2020-11-13 10:56:55.9954587', N'查看用户列表', N'::1', N'查询', N'2020-11-13 10:56:55.9954587', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'27', N'admin', N'2020-11-13 10:56:56.0114157', N'用户查看管理员列表', N'::1', N'查看', N'2020-11-13 10:56:56.0114157', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'28', N'admin', N'2020-11-13 14:49:02.2954329', N'查看用户列表', N'::1', N'查询', N'2020-11-13 14:49:02.2954329', N'系统管理员')
GO

INSERT INTO [dbo].[SystemLog] ([ID], [UserName], [TimeStr], [ActionStr], [IPAddress], [Type], [AddTime], [AddPeople]) VALUES (N'37', N'admin', N'2020-11-13 18:21:51.4639129', N'查看用户列表', N'::1', N'查询', N'2020-11-13 18:21:51.4639129', N'系统管理员')
GO

SET IDENTITY_INSERT [dbo].[SystemLog] OFF
GO


-- ----------------------------
-- Table structure for SystemMenu
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SystemMenu]') AND type IN ('U'))
	DROP TABLE [dbo].[SystemMenu]
GO

CREATE TABLE [dbo].[SystemMenu] (
  [ModuleID] int  IDENTITY(1,1) NOT NULL,
  [FullName] varchar(100) COLLATE Chinese_PRC_CI_AS  NULL,
  [ParentID] int  NULL,
  [Category] varchar(100) COLLATE Chinese_PRC_CI_AS  NULL,
  [Icon] varchar(100) COLLATE Chinese_PRC_CI_AS  NULL,
  [Target] varchar(100) COLLATE Chinese_PRC_CI_AS  NULL,
  [Level] varchar(100) COLLATE Chinese_PRC_CI_AS  NULL,
  [SortCode] varchar(100) COLLATE Chinese_PRC_CI_AS  NULL,
  [Location] varchar(100) COLLATE Chinese_PRC_CI_AS  NULL,
  [Remark] varchar(100) COLLATE Chinese_PRC_CI_AS  NULL,
  [MenuRole] varchar(100) COLLATE Chinese_PRC_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[SystemMenu] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'模块id







',
'SCHEMA', N'dbo',
'TABLE', N'SystemMenu',
'COLUMN', N'ModuleID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'模块名称',
'SCHEMA', N'dbo',
'TABLE', N'SystemMenu',
'COLUMN', N'FullName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'父级菜单id',
'SCHEMA', N'dbo',
'TABLE', N'SystemMenu',
'COLUMN', N'ParentID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'分类(页面或者目录)',
'SCHEMA', N'dbo',
'TABLE', N'SystemMenu',
'COLUMN', N'Category'
GO

EXEC sp_addextendedproperty
'MS_Description', N'图标',
'SCHEMA', N'dbo',
'TABLE', N'SystemMenu',
'COLUMN', N'Icon'
GO

EXEC sp_addextendedproperty
'MS_Description', N'连接目标',
'SCHEMA', N'dbo',
'TABLE', N'SystemMenu',
'COLUMN', N'Target'
GO

EXEC sp_addextendedproperty
'MS_Description', N'级别层次
',
'SCHEMA', N'dbo',
'TABLE', N'SystemMenu',
'COLUMN', N'Level'
GO

EXEC sp_addextendedproperty
'MS_Description', N'显示顺序',
'SCHEMA', N'dbo',
'TABLE', N'SystemMenu',
'COLUMN', N'SortCode'
GO

EXEC sp_addextendedproperty
'MS_Description', N'地址',
'SCHEMA', N'dbo',
'TABLE', N'SystemMenu',
'COLUMN', N'Location'
GO

EXEC sp_addextendedproperty
'MS_Description', N'备注说明',
'SCHEMA', N'dbo',
'TABLE', N'SystemMenu',
'COLUMN', N'Remark'
GO

EXEC sp_addextendedproperty
'MS_Description', N'权限字符串',
'SCHEMA', N'dbo',
'TABLE', N'SystemMenu',
'COLUMN', N'MenuRole'
GO

EXEC sp_addextendedproperty
'MS_Description', N'系统菜单表',
'SCHEMA', N'dbo',
'TABLE', N'SystemMenu'
GO


-- ----------------------------
-- Records of SystemMenu
-- ----------------------------
SET IDENTITY_INSERT [dbo].[SystemMenu] ON
GO

INSERT INTO [dbo].[SystemMenu] ([ModuleID], [FullName], [ParentID], [Category], [Icon], [Target], [Level], [SortCode], [Location], [Remark], [MenuRole]) VALUES (N'1', N'企业项目管理', N'0', N'目录', N'el-icon-paper-clip bs_ttip first_level_icon', N'iframe', N'1', N'4', N'目录', NULL, N'EP')
GO

INSERT INTO [dbo].[SystemMenu] ([ModuleID], [FullName], [ParentID], [Category], [Icon], [Target], [Level], [SortCode], [Location], [Remark], [MenuRole]) VALUES (N'2', N'结算管理', N'0', N'目录', N'el-icon-cog first_level_icon', N'iframe', N'1', N'2', N'目录', NULL, N'JS')
GO

INSERT INTO [dbo].[SystemMenu] ([ModuleID], [FullName], [ParentID], [Category], [Icon], [Target], [Level], [SortCode], [Location], [Remark], [MenuRole]) VALUES (N'3', N'收付款管理', N'2', N'页面', N'pingan_icon_07.png', N'iframe', N'2', N'2', N'/General/Financial/FinancialList.aspx', NULL, N'Financial')
GO

INSERT INTO [dbo].[SystemMenu] ([ModuleID], [FullName], [ParentID], [Category], [Icon], [Target], [Level], [SortCode], [Location], [Remark], [MenuRole]) VALUES (N'4', N'人员工作量管理', N'2', N'页面', N'pinggu_icon_03.png', N'iframe', N'1', N'3', N'/General/Employee/EmployeeList.aspx', NULL, N'Employee')
GO

INSERT INTO [dbo].[SystemMenu] ([ModuleID], [FullName], [ParentID], [Category], [Icon], [Target], [Level], [SortCode], [Location], [Remark], [MenuRole]) VALUES (N'5', N'系统管理', N'0', N'目录', N'el-icon-cog first_level_icon', N'iframe', N'1', N'5', N'目录', NULL, N'SYSTEM')
GO

INSERT INTO [dbo].[SystemMenu] ([ModuleID], [FullName], [ParentID], [Category], [Icon], [Target], [Level], [SortCode], [Location], [Remark], [MenuRole]) VALUES (N'6', N'用户管理', N'5', N'页面', N'pinggu_icon_03.png', N'iframe', N'1', N'3', N'/General/SystemManage/SystemUserList.aspx', N'', N'SystemUser')
GO

INSERT INTO [dbo].[SystemMenu] ([ModuleID], [FullName], [ParentID], [Category], [Icon], [Target], [Level], [SortCode], [Location], [Remark], [MenuRole]) VALUES (N'7', N'系统配置', N'5', N'页面', N'pinggu_icon_03.png', N'iframe', N'1', N'2', N'/General/SystemManage/SystemSetting.aspx', NULL, N'SystemSetting')
GO

INSERT INTO [dbo].[SystemMenu] ([ModuleID], [FullName], [ParentID], [Category], [Icon], [Target], [Level], [SortCode], [Location], [Remark], [MenuRole]) VALUES (N'8', N'系统日志', N'5', N'页面', N'pinggu_icon_03.png', N'iframe', N'1', N'2', N'/General/SystemManage/SystemLog.aspx', NULL, N'SystemLog')
GO

INSERT INTO [dbo].[SystemMenu] ([ModuleID], [FullName], [ParentID], [Category], [Icon], [Target], [Level], [SortCode], [Location], [Remark], [MenuRole]) VALUES (N'9', N'菜单管理', N'5', N'页面', N'pinggu_icon_03.png', N'iframe', N'1', N'3', N'/General/SystemManage/SystemMenuList.aspx', NULL, N'SystemMenu')
GO

INSERT INTO [dbo].[SystemMenu] ([ModuleID], [FullName], [ParentID], [Category], [Icon], [Target], [Level], [SortCode], [Location], [Remark], [MenuRole]) VALUES (N'10', N'角色管理', N'5', N'页面', N'pinggu_icon_03.png', N'iframe', N'1', N'2', N'/General/SystemManage/SystemRolesList.aspx', NULL, N'SystemRoles')
GO

INSERT INTO [dbo].[SystemMenu] ([ModuleID], [FullName], [ParentID], [Category], [Icon], [Target], [Level], [SortCode], [Location], [Remark], [MenuRole]) VALUES (N'11', N'统计分析', N'0', N'目录', N'el-icon-indent-left bs_ttip first_level_icon', N'iframe', N'0', N'1', N'目录', NULL, N'TJFX')
GO

INSERT INTO [dbo].[SystemMenu] ([ModuleID], [FullName], [ParentID], [Category], [Icon], [Target], [Level], [SortCode], [Location], [Remark], [MenuRole]) VALUES (N'12', N'项目开发情况分析', N'11', N'页面', N'pinggu_icon_03.png', N'iframe', N'2', N'8', N'/General/Statistical/ProjectAnalyze.aspx', NULL, N'XmkfFX')
GO

INSERT INTO [dbo].[SystemMenu] ([ModuleID], [FullName], [ParentID], [Category], [Icon], [Target], [Level], [SortCode], [Location], [Remark], [MenuRole]) VALUES (N'13', N'项目参与人数的统计', N'11', N'页面', N'pinggu_icon_03.png', N'iframe', N'2', N'99', N'/General/Statistical/PersonParticipate.aspx', N'', N'XmpersonFX')
GO

INSERT INTO [dbo].[SystemMenu] ([ModuleID], [FullName], [ParentID], [Category], [Icon], [Target], [Level], [SortCode], [Location], [Remark], [MenuRole]) VALUES (N'14', N'人员平均工作量分析', N'11', N'页面', N'pinggu_icon_03.png', N'iframe', N'2', N'88', N'/General/Statistical/Average.aspx', N'', N'personFX')
GO

INSERT INTO [dbo].[SystemMenu] ([ModuleID], [FullName], [ParentID], [Category], [Icon], [Target], [Level], [SortCode], [Location], [Remark], [MenuRole]) VALUES (N'15', N'企业列表', N'1', N'页面', N'pinggu_icon_03.png', N'iframe', N'2', N'5', N'/General/Enterprise/EnterpriseList.aspx', NULL, N'Enterprise')
GO

INSERT INTO [dbo].[SystemMenu] ([ModuleID], [FullName], [ParentID], [Category], [Icon], [Target], [Level], [SortCode], [Location], [Remark], [MenuRole]) VALUES (N'16', N'合同列表', N'1', N'页面', N'pinggu_icon_03.png', N'iframe', N'2', N'4', N'/General/Contract/ContractList.aspx', NULL, N'Contract')
GO

INSERT INTO [dbo].[SystemMenu] ([ModuleID], [FullName], [ParentID], [Category], [Icon], [Target], [Level], [SortCode], [Location], [Remark], [MenuRole]) VALUES (N'17', N'项目列表', N'1', N'页面', N'pinggu_icon_03.png', N'iframe', N'2', N'2', N'/General/Project/ProjectList.aspx', NULL, N'Project')
GO

INSERT INTO [dbo].[SystemMenu] ([ModuleID], [FullName], [ParentID], [Category], [Icon], [Target], [Level], [SortCode], [Location], [Remark], [MenuRole]) VALUES (N'18', N'财务收入情况统计分析', N'11', N'页面', N'pinggu_icon_03.png', N'iframe', N'22', N'999', N'/General/Statistical/FinancialAnalysis.aspx', N'', N'FinancialFX')
GO

SET IDENTITY_INSERT [dbo].[SystemMenu] OFF
GO


-- ----------------------------
-- Table structure for SystemRoles
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SystemRoles]') AND type IN ('U'))
	DROP TABLE [dbo].[SystemRoles]
GO

CREATE TABLE [dbo].[SystemRoles] (
  [ID] int  IDENTITY(1,1) NOT NULL,
  [RoleName] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [Remarks] varchar(1000) COLLATE Chinese_PRC_CI_AS  NULL,
  [Actionstr] nvarchar(max) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [IsDelete] int  NOT NULL,
  [AddTime] varchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [AddPeople] varchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[SystemRoles] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'角色名称',
'SCHEMA', N'dbo',
'TABLE', N'SystemRoles',
'COLUMN', N'RoleName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'备注信息',
'SCHEMA', N'dbo',
'TABLE', N'SystemRoles',
'COLUMN', N'Remarks'
GO

EXEC sp_addextendedproperty
'MS_Description', N'权限字符串',
'SCHEMA', N'dbo',
'TABLE', N'SystemRoles',
'COLUMN', N'Actionstr'
GO

EXEC sp_addextendedproperty
'MS_Description', N'是否删除0：是1：否',
'SCHEMA', N'dbo',
'TABLE', N'SystemRoles',
'COLUMN', N'IsDelete'
GO

EXEC sp_addextendedproperty
'MS_Description', N'添加时间',
'SCHEMA', N'dbo',
'TABLE', N'SystemRoles',
'COLUMN', N'AddTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'添加人',
'SCHEMA', N'dbo',
'TABLE', N'SystemRoles',
'COLUMN', N'AddPeople'
GO

EXEC sp_addextendedproperty
'MS_Description', N'系统角色表',
'SCHEMA', N'dbo',
'TABLE', N'SystemRoles'
GO


-- ----------------------------
-- Records of SystemRoles
-- ----------------------------
SET IDENTITY_INSERT [dbo].[SystemRoles] ON
GO

INSERT INTO [dbo].[SystemRoles] ([ID], [RoleName], [Remarks], [Actionstr], [IsDelete], [AddTime], [AddPeople]) VALUES (N'4', N'系统管理员', NULL, N'|EP||EnterpriseShow||EnterpriseList||Enterprise||EnterpriseAdd||EnterpriseModify||EnterpriseDel||EnterpriseImport||EnterpriseExport||Enterpriseprint||Enterprisesearch||Enterpriserefresh||Enterpriseaccredit||EnterpriseAllShow||EP||ContractShow||ContractList||Contract||ContractAdd||ContractModify||ContractDel||ContractImport||ContractExport||Contractprint||Contractsearch||Contractrefresh||Contractaccredit||ContractAllShow||EP||ProjectShow||ProjectList||Project||ProjectAdd||ProjectModify||ProjectDel||ProjectImport||ProjectExport||Projectprint||Projectsearch||Projectrefresh||Projectaccredit||ProjectAllShow||EP||9Show||9List||9||9Add||9Modify||9Del||9Import||9Export||9print||9search||9refresh||9accredit||9AllShow||EP||6Show||6List||6||6Add||6Modify||6Del||6Import||6Export||6print||6search||6refresh||6accredit||6AllShow||EP||4Show||4List||4||4Add||4Modify||4Del||4Import||4Export||4print||4search||4refresh||4accredit||4AllShow||EP||2Show||2List||2||2Add||2Modify||2Del||2Import||2Export||2print||2search||2refresh||2accredit||2AllShow||JS||FinancialShow||FinancialList||Financial||FinancialAdd||FinancialModify||FinancialDel||FinancialImport||FinancialExport||Financialprint||Financialsearch||Financialrefresh||Financialaccredit||FinancialAllShow||JS||EmployeeShow||EmployeeList||Employee||EmployeeAdd||EmployeeModify||EmployeeDel||EmployeeImport||EmployeeExport||Employeeprint||Employeesearch||Employeerefresh||Employeeaccredit||EmployeeAllShow||SYSTEM||SystemUserShow||SystemUserList||SystemUser||SystemUserAdd||SystemUserModify||SystemUserDel||SystemUserImport||SystemUserExport||SystemUserprint||SystemUsersearch||SystemUserrefresh||SystemUseraccredit||SystemUserAllShow||SYSTEM||SystemSettingShow||SystemSettingList||SystemSetting||SystemSettingAdd||SystemSettingModify||SystemSettingDel||SystemSettingImport||SystemSettingExport||SystemSettingprint||SystemSettingsearch||SystemSettingrefresh||SystemSettingaccredit||SystemSettingAllShow||SYSTEM||SystemLogShow||SystemLogList||SystemLog||SystemLogAdd||SystemLogModify||SystemLogDel||SystemLogImport||SystemLogExport||SystemLogprint||SystemLogsearch||SystemLogrefresh||SystemLogaccredit||SystemLogAllShow||SYSTEM||SystemMenuShow||SystemMenuList||SystemMenu||SystemMenuAdd||SystemMenuModify||SystemMenuDel||SystemMenuImport||SystemMenuExport||SystemMenuprint||SystemMenusearch||SystemMenurefresh||SystemMenuaccredit||SystemMenuAllShow||SYSTEM||SystemRolesShow||SystemRolesList||SystemRoles||SystemRolesAdd||SystemRolesModify||SystemRolesDel||SystemRolesImport||SystemRolesExport||SystemRolesprint||SystemRolessearch||SystemRolesrefresh||SystemRolesaccredit||SystemRolesAllShow||TJFX||XmkfFXShow||XmkfFXList||XmkfFX||XmkfFXAdd||XmkfFXModify||XmkfFXDel||XmkfFXImport||XmkfFXExport||XmkfFXprint||XmkfFXsearch||XmkfFXrefresh||XmkfFXaccredit||XmkfFXAllShow||TJFX||XmpersonFXShow||XmpersonFXList||XmpersonFX||XmpersonFXAdd||XmpersonFXModify||XmpersonFXDel||XmpersonFXImport||XmpersonFXExport||XmpersonFXprint||XmpersonFXsearch||XmpersonFXrefresh||XmpersonFXaccredit||XmpersonFXAllShow||TJFX||personFXShow||personFXList||personFX||personFXAdd||personFXModify||personFXDel||personFXImport||personFXExport||personFXprint||personFXsearch||personFXrefresh||personFXaccredit||personFXAllShow||TJFX||FinancialFXShow||FinancialFXList||FinancialFX||FinancialFXAdd||FinancialFXModify||FinancialFXDel||FinancialFXImport||FinancialFXExport||FinancialFXprint||FinancialFXsearch||FinancialFXrefresh||FinancialFXaccredit||FinancialFXAllShow|', N'1', N'2016-04-15 11:16:29.0000000', N'系统管理员')
GO

INSERT INTO [dbo].[SystemRoles] ([ID], [RoleName], [Remarks], [Actionstr], [IsDelete], [AddTime], [AddPeople]) VALUES (N'6', N'旅游与酒店管理学院领导', NULL, N' ', N'1', N'2016-04-15 11:16:29.0000000', N'系统管理员')
GO

INSERT INTO [dbo].[SystemRoles] ([ID], [RoleName], [Remarks], [Actionstr], [IsDelete], [AddTime], [AddPeople]) VALUES (N'7', N'旅游与酒店管理学院教师', NULL, N'|EP||EnterpriseShow||EnterpriseList||Enterprise||EnterpriseAdd||EnterpriseModify||EnterpriseDel||EnterpriseImport||EnterpriseExport||Enterpriseprint||Enterprisesearch||Enterpriserefresh||Enterpriseaccredit||EnterpriseAllShow||EP||ContractShow||ContractList||Contract||ContractAdd||ContractModify||ContractDel||ContractImport||ContractExport||Contractprint||Contractsearch||Contractrefresh||Contractaccredit||ContractAllShow||EP||ProjectShow||ProjectList||Project||ProjectAdd||ProjectModify||ProjectDel||ProjectImport||ProjectExport||Projectprint||Projectsearch||Projectrefresh||Projectaccredit||ProjectAllShow||JS||FinancialShow||FinancialList||Financial||FinancialAdd||FinancialModify||FinancialDel||FinancialImport||FinancialExport||Financialprint||Financialsearch||Financialrefresh||Financialaccredit||FinancialAllShow||JS||EmployeeShow||EmployeeList||Employee||EmployeeAdd||EmployeeModify||EmployeeDel||EmployeeImport||EmployeeExport||Employeeprint||Employeesearch||Employeerefresh||Employeeaccredit||EmployeeAllShow|', N'1', N'2016-04-15 11:16:29.0000000', N'系统管理员')
GO

INSERT INTO [dbo].[SystemRoles] ([ID], [RoleName], [Remarks], [Actionstr], [IsDelete], [AddTime], [AddPeople]) VALUES (N'8', N'文华分院领导', NULL, N'|JS||FinancialShow||FinancialList||Financial||FinancialAdd||FinancialModify||FinancialDel||FinancialImport||FinancialExport||Financialprint||Financialsearch||Financialrefresh||Financialaccredit||FinancialAllShow||JS||EmployeeShow||EmployeeList||Employee||EmployeeAdd||EmployeeModify||EmployeeDel||EmployeeImport||EmployeeExport||Employeeprint||Employeesearch||Employeerefresh||Employeeaccredit||EmployeeAllShow||TJFX||XmkfFXShow||XmkfFXList||XmkfFX||XmkfFXAdd||XmkfFXModify||XmkfFXDel||XmkfFXImport||XmkfFXExport||XmkfFXprint||XmkfFXsearch||XmkfFXrefresh||XmkfFXaccredit||XmkfFXAllShow||TJFX||XmpersonFXShow||XmpersonFXList||XmpersonFX||XmpersonFXAdd||XmpersonFXModify||XmpersonFXDel||XmpersonFXImport||XmpersonFXExport||XmpersonFXprint||XmpersonFXsearch||XmpersonFXrefresh||XmpersonFXaccredit||XmpersonFXAllShow||TJFX||personFXShow||personFXList||personFX||personFXAdd||personFXModify||personFXDel||personFXImport||personFXExport||personFXprint||personFXsearch||personFXrefresh||personFXaccredit||personFXAllShow||TJFX||FinancialFXShow||FinancialFXList||FinancialFX||FinancialFXAdd||FinancialFXModify||FinancialFXDel||FinancialFXImport||FinancialFXExport||FinancialFXprint||FinancialFXsearch||FinancialFXrefresh||FinancialFXaccredit||FinancialFXAllShow|', N'1', N'2016-04-15 11:16:29.0000000', N'系统管理员')
GO

INSERT INTO [dbo].[SystemRoles] ([ID], [RoleName], [Remarks], [Actionstr], [IsDelete], [AddTime], [AddPeople]) VALUES (N'9', N'文华分院教师', NULL, N'|EP||EnterpriseShow||EnterpriseList||Enterprise||EnterpriseAdd||EnterpriseModify||EnterpriseDel||Enterpriserefresh||EnterpriseAllShow||EP||ContractShow||ContractList||Contract||ContractAdd||ContractModify||ContractDel||Contractrefresh||ContractAllShow||EP||ProjectShow||ProjectList||Project||ProjectAdd||ProjectModify||Projectrefresh||ProjectAllShow|', N'1', N'2016-04-15 11:16:29.0000000', N'系统管理员')
GO

INSERT INTO [dbo].[SystemRoles] ([ID], [RoleName], [Remarks], [Actionstr], [IsDelete], [AddTime], [AddPeople]) VALUES (N'13', N'电子商务学院老师', NULL, N' ', N'1', N'2016-04-15 11:16:29.0000000', N'系统管理员')
GO

INSERT INTO [dbo].[SystemRoles] ([ID], [RoleName], [Remarks], [Actionstr], [IsDelete], [AddTime], [AddPeople]) VALUES (N'10', N'外国语学院领导', NULL, N' ', N'1', N'2016-04-15 11:16:29.0000000', N'系统管理员')
GO

INSERT INTO [dbo].[SystemRoles] ([ID], [RoleName], [Remarks], [Actionstr], [IsDelete], [AddTime], [AddPeople]) VALUES (N'11', N'外国语学院老师', NULL, N'|EP||EnterpriseShow||EnterpriseList||Enterprise||EnterpriseAdd||EnterpriseModify||EnterpriseDel||EnterpriseImport||EnterpriseExport||Enterpriseprint||Enterprisesearch||Enterpriserefresh||Enterpriseaccredit||EnterpriseAllShow||EP||ContractShow||ContractList||Contract||ContractAdd||ContractModify||ContractDel||ContractImport||ContractExport||Contractprint||Contractsearch||Contractrefresh||Contractaccredit||ContractAllShow||EP||ProjectShow||ProjectList||Project||ProjectAdd||ProjectModify||ProjectDel||ProjectImport||ProjectExport||Projectprint||Projectsearch||Projectrefresh||Projectaccredit||ProjectAllShow||EP||9Show||9List||9||9Add||9Modify||9Del||9Import||9Export||9print||9search||9refresh||9accredit||9AllShow||EP||6Show||6List||6||6Add||6Modify||6Del||6Import||6Export||6print||6search||6refresh||6accredit||6AllShow||EP||4Show||4List||4||4Add||4Modify||4Del||4Import||4Export||4print||4search||4refresh||4accredit||4AllShow||EP||2Show||2List||2||2Add||2Modify||2Del||2Import||2Export||2print||2search||2refresh||2accredit||2AllShow||JS||FinancialShow||FinancialList||Financial||FinancialAdd||FinancialModify||FinancialDel||FinancialImport||FinancialExport||Financialprint||Financialsearch||Financialrefresh||Financialaccredit||FinancialAllShow||JS||EmployeeShow||EmployeeList||Employee||EmployeeAdd||EmployeeModify||EmployeeDel||EmployeeImport||EmployeeExport||Employeeprint||Employeesearch||Employeerefresh||Employeeaccredit||EmployeeAllShow||SYSTEM||SystemUserShow||SystemUserList||SystemUser||SystemUserAdd||SystemUserModify||SystemUserDel||SystemUserImport||SystemUserExport||SystemUserprint||SystemUsersearch||SystemUserrefresh||SystemUseraccredit||SystemUserAllShow||SYSTEM||SystemSettingShow||SystemSettingList||SystemSetting||SystemSettingAdd||SystemSettingModify||SystemSettingDel||SystemSettingImport||SystemSettingExport||SystemSettingprint||SystemSettingsearch||SystemSettingrefresh||SystemSettingaccredit||SystemSettingAllShow||SYSTEM||SystemLogShow||SystemLogList||SystemLog||SystemLogAdd||SystemLogModify||SystemLogDel||SystemLogImport||SystemLogExport||SystemLogprint||SystemLogsearch||SystemLogrefresh||SystemLogaccredit||SystemLogAllShow||SYSTEM||SystemMenuShow||SystemMenuList||SystemMenu||SystemMenuAdd||SystemMenuModify||SystemMenuDel||SystemMenuImport||SystemMenuExport||SystemMenuprint||SystemMenusearch||SystemMenurefresh||SystemMenuaccredit||SystemMenuAllShow||SYSTEM||SystemRolesShow||SystemRolesList||SystemRoles||SystemRolesAdd||SystemRolesModify||SystemRolesDel||SystemRolesImport||SystemRolesExport||SystemRolesprint||SystemRolessearch||SystemRolesrefresh||SystemRolesaccredit||SystemRolesAllShow||TJFX||XmkfFXShow||XmkfFXList||XmkfFX||XmkfFXAdd||XmkfFXModify||XmkfFXDel||XmkfFXImport||XmkfFXExport||XmkfFXprint||XmkfFXsearch||XmkfFXrefresh||XmkfFXaccredit||XmkfFXAllShow||TJFX||XmpersonFXShow||XmpersonFXList||XmpersonFX||XmpersonFXAdd||XmpersonFXModify||XmpersonFXDel||XmpersonFXImport||XmpersonFXExport||XmpersonFXprint||XmpersonFXsearch||XmpersonFXrefresh||XmpersonFXaccredit||XmpersonFXAllShow||TJFX||personFXShow||personFXList||personFX||personFXAdd||personFXModify||personFXDel||personFXImport||personFXExport||personFXprint||personFXsearch||personFXrefresh||personFXaccredit||personFXAllShow||TJFX||FinancialFXShow||FinancialFXList||FinancialFX||FinancialFXAdd||FinancialFXModify||FinancialFXDel||FinancialFXImport||FinancialFXExport||FinancialFXprint||FinancialFXsearch||FinancialFXrefresh||FinancialFXaccredit||FinancialFXAllShow|', N'1', N'2016-04-15 11:16:29.0000000', N'系统管理员')
GO

INSERT INTO [dbo].[SystemRoles] ([ID], [RoleName], [Remarks], [Actionstr], [IsDelete], [AddTime], [AddPeople]) VALUES (N'12', N'电子商务学院领导', NULL, N'|EP||EnterpriseShow||EnterpriseList||Enterprise||EnterpriseAdd||EnterpriseModify||EnterpriseDel||EnterpriseImport||EnterpriseExport||Enterpriseprint||Enterprisesearch||Enterpriserefresh||Enterpriseaccredit||EnterpriseAllShow||EP||ContractShow||ContractList||Contract||ContractAdd||ContractModify||ContractDel||ContractImport||ContractExport||Contractprint||Contractsearch||Contractrefresh||Contractaccredit||ContractAllShow||EP||ProjectShow||ProjectList||Project||ProjectAdd||ProjectModify||ProjectDel||ProjectImport||ProjectExport||Projectprint||Projectsearch||Projectrefresh||Projectaccredit||ProjectAllShow||EP||9Show||9List||9||9Add||9Modify||9Del||9Import||9Export||9print||9search||9refresh||9accredit||9AllShow||EP||6Show||6List||6||6Add||6Modify||6Del||6Import||6Export||6print||6search||6refresh||6accredit||6AllShow||EP||6Show||6List||6||6Add||6Modify||6Del||6Import||6Export||6print||6search||6refresh||6accredit||6AllShow||EP||6Show||6List||6||6Add||6Modify||6Del||6Import||6Export||6print||6search||6refresh||6accredit||6AllShow||EP||4Show||4List||4||4Add||4Modify||4Del||4Import||4Export||4print||4search||4refresh||4accredit||4AllShow||EP||1Show||1List||1||1Add||1Modify||1Del||1Import||1Export||1print||1search||1refresh||1accredit||1AllShow|', N'1', N'2016-04-15 11:16:29.0000000', N'系统管理员')
GO

INSERT INTO [dbo].[SystemRoles] ([ID], [RoleName], [Remarks], [Actionstr], [IsDelete], [AddTime], [AddPeople]) VALUES (N'14', N'华语老师', NULL, N'|EP||EnterpriseShow||EnterpriseList||Enterprise||EnterpriseAdd||EnterpriseModify||EnterpriseDel||EnterpriseImport||EnterpriseExport||Enterpriseprint||Enterprisesearch||Enterpriserefresh||Enterpriseaccredit||EnterpriseAllShow||EP||ContractShow||ContractList||Contract||ContractAdd||ContractModify||ContractDel||ContractImport||ContractExport||Contractprint||Contractsearch||Contractrefresh||Contractaccredit||ContractAllShow||EP||ProjectShow||ProjectList||Project||ProjectAdd||ProjectModify||ProjectDel||ProjectImport||ProjectExport||Projectprint||Projectsearch||Projectrefresh||Projectaccredit||ProjectAllShow||JS||FinancialShow||FinancialList||Financial||FinancialAdd||FinancialModify||FinancialDel||FinancialImport||FinancialExport||Financialprint||Financialsearch||Financialrefresh||Financialaccredit||FinancialAllShow||JS||EmployeeShow||EmployeeList||Employee||EmployeeAdd||EmployeeModify||EmployeeDel||EmployeeImport||EmployeeExport||Employeeprint||Employeesearch||Employeerefresh||Employeeaccredit||EmployeeAllShow||SYSTEM||SystemUserShow||SystemUserList||SystemUser||SystemUserAdd||SystemUserModify||SystemUserDel||SystemUserImport||SystemUserExport||SystemUserprint||SystemUsersearch||SystemUserrefresh||SystemUseraccredit||SystemUserAllShow||SYSTEM||SystemSettingShow||SystemSettingList||SystemSetting||SystemSettingAdd||SystemSettingModify||SystemSettingDel||SystemSettingImport||SystemSettingExport||SystemSettingprint||SystemSettingsearch||SystemSettingrefresh||SystemSettingaccredit||SystemSettingAllShow||SYSTEM||SystemLogShow||SystemLogList||SystemLog||SystemLogAdd||SystemLogModify||SystemLogDel||SystemLogImport||SystemLogExport||SystemLogprint||SystemLogsearch||SystemLogrefresh||SystemLogaccredit||SystemLogAllShow||SYSTEM||SystemMenuShow||SystemMenuList||SystemMenu||SystemMenuAdd||SystemMenuModify||SystemMenuDel||SystemMenuImport||SystemMenuExport||SystemMenuprint||SystemMenusearch||SystemMenurefresh||SystemMenuaccredit||SystemMenuAllShow||SYSTEM||SystemRolesShow||SystemRolesList||SystemRoles||SystemRolesAdd||SystemRolesModify||SystemRolesDel||SystemRolesImport||SystemRolesExport||SystemRolesprint||SystemRolessearch||SystemRolesrefresh||SystemRolesaccredit||SystemRolesAllShow||TJFX||XmkfFXShow||XmkfFXList||XmkfFX||XmkfFXAdd||XmkfFXModify||XmkfFXDel||XmkfFXImport||XmkfFXExport||XmkfFXprint||XmkfFXsearch||XmkfFXrefresh||XmkfFXaccredit||XmkfFXAllShow||TJFX||XmpersonFXShow||XmpersonFXList||XmpersonFX||XmpersonFXAdd||XmpersonFXModify||XmpersonFXDel||XmpersonFXImport||XmpersonFXExport||XmpersonFXprint||XmpersonFXsearch||XmpersonFXrefresh||XmpersonFXaccredit||XmpersonFXAllShow||TJFX||personFXShow||personFXList||personFX||personFXAdd||personFXModify||personFXDel||personFXImport||personFXExport||personFXprint||personFXsearch||personFXrefresh||personFXaccredit||personFXAllShow||TJFX||FinancialFXShow||FinancialFXList||FinancialFX||FinancialFXAdd||FinancialFXModify||FinancialFXDel||FinancialFXImport||FinancialFXExport||FinancialFXprint||FinancialFXsearch||FinancialFXrefresh||FinancialFXaccredit||FinancialFXAllShow|', N'1', N'2016-04-15 11:16:29.0000000', N'系统管理员')
GO

INSERT INTO [dbo].[SystemRoles] ([ID], [RoleName], [Remarks], [Actionstr], [IsDelete], [AddTime], [AddPeople]) VALUES (N'15', N'德旺老师', NULL, N' ', N'1', N'2016-04-15 11:16:29.0000000', N'系统管理员')
GO

INSERT INTO [dbo].[SystemRoles] ([ID], [RoleName], [Remarks], [Actionstr], [IsDelete], [AddTime], [AddPeople]) VALUES (N'16', N'学校领导', N'', N'|EP||EnterpriseShow||EnterpriseList||Enterprise||EnterpriseAdd||EnterpriseModify||EnterpriseDel||EnterpriseImport||EnterpriseExport||EnterpriseAllShow||EP||ContractShow||ContractList||Contract||ContractAdd||ContractModify||ContractDel||ContractImport||ContractExport||ContractAllShow||EP||ProjectShow||ProjectList||Project||ProjectAdd||ProjectModify||ProjectDel||ProjectImport||ProjectExport||ProjectAllShow||JS||FinancialShow||FinancialList||Financial||FinancialAdd||FinancialModify||FinancialDel||FinancialImport||FinancialExport||FinancialAllShow||JS||EmployeeShow||EmployeeList||Employee||EmployeeAdd||EmployeeModify||EmployeeDel||EmployeeImport||EmployeeExport||EmployeeAllShow||SYSTEM||SystemUserShow||SystemUserList||SystemUser||SystemUserAdd||SystemUserModify||SystemUserDel||SystemUserImport||SystemUserExport||SystemUserAllShow||SYSTEM||SystemSettingShow||SystemSettingList||SystemSetting||SystemSettingAdd||SystemSettingModify||SystemSettingDel||SystemSettingImport||SystemSettingExport||SystemSettingAllShow||SYSTEM||SystemLogShow||SystemLogList||SystemLog||SystemLogAdd||SystemLogModify||SystemLogDel||SystemLogImport||SystemLogExport||SystemLogAllShow||SYSTEM||SystemMenuShow||SystemMenuList||SystemMenu||SystemMenuAdd||SystemMenuModify||SystemMenuDel||SystemMenuImport||SystemMenuExport||SystemMenuAllShow||SYSTEM||SystemRolesShow||SystemRolesList||SystemRoles||SystemRolesAdd||SystemRolesModify||SystemRolesDel||SystemRolesImport||SystemRolesExport||SystemRolesAllShow||TJFX||XmkfFXShow||XmkfFXList||XmkfFX||XmkfFXAdd||XmkfFXModify||XmkfFXDel||XmkfFXImport||XmkfFXExport||XmkfFXAllShow||TJFX||XmpersonFXShow||XmpersonFXList||XmpersonFX||XmpersonFXAdd||XmpersonFXModify||XmpersonFXDel||XmpersonFXImport||XmpersonFXExport||XmpersonFXAllShow||TJFX||personFXShow||personFXList||personFX||personFXAdd||personFXModify||personFXDel||personFXImport||personFXExport||personFXAllShow||TJFX||FinancialFXShow||FinancialFXList||FinancialFX||FinancialFXAdd||FinancialFXModify||FinancialFXDel||FinancialFXImport||FinancialFXExport||FinancialFXAllShow|', N'1', N'2016-04-15 11:16:29.0000000', N'系统管理员')
GO

SET IDENTITY_INSERT [dbo].[SystemRoles] OFF
GO


-- ----------------------------
-- Table structure for SystemSetting
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SystemSetting]') AND type IN ('U'))
	DROP TABLE [dbo].[SystemSetting]
GO

CREATE TABLE [dbo].[SystemSetting] (
  [ID] int  IDENTITY(1,1) NOT NULL,
  [SystemName] varchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [SystemPicture] varchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [Email] varchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [smtpSeverName] varchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [EmailName] varchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [Emailpwd] varchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [FileType] varchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [IsIdentifyingCode] int  NOT NULL
)
GO

ALTER TABLE [dbo].[SystemSetting] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'标识主键ID',
'SCHEMA', N'dbo',
'TABLE', N'SystemSetting',
'COLUMN', N'ID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'系统名称',
'SCHEMA', N'dbo',
'TABLE', N'SystemSetting',
'COLUMN', N'SystemName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'图片',
'SCHEMA', N'dbo',
'TABLE', N'SystemSetting',
'COLUMN', N'SystemPicture'
GO

EXEC sp_addextendedproperty
'MS_Description', N'邮箱',
'SCHEMA', N'dbo',
'TABLE', N'SystemSetting',
'COLUMN', N'Email'
GO

EXEC sp_addextendedproperty
'MS_Description', N'smtp服务器名称',
'SCHEMA', N'dbo',
'TABLE', N'SystemSetting',
'COLUMN', N'smtpSeverName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'邮箱登录名',
'SCHEMA', N'dbo',
'TABLE', N'SystemSetting',
'COLUMN', N'EmailName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'邮箱密码（授权码）',
'SCHEMA', N'dbo',
'TABLE', N'SystemSetting',
'COLUMN', N'Emailpwd'
GO

EXEC sp_addextendedproperty
'MS_Description', N'上传文件类型',
'SCHEMA', N'dbo',
'TABLE', N'SystemSetting',
'COLUMN', N'FileType'
GO

EXEC sp_addextendedproperty
'MS_Description', N'是否显示验证码，如果不为0就隐藏',
'SCHEMA', N'dbo',
'TABLE', N'SystemSetting',
'COLUMN', N'IsIdentifyingCode'
GO

EXEC sp_addextendedproperty
'MS_Description', N'全局设置',
'SCHEMA', N'dbo',
'TABLE', N'SystemSetting'
GO


-- ----------------------------
-- Records of SystemSetting
-- ----------------------------
SET IDENTITY_INSERT [dbo].[SystemSetting] ON
GO

INSERT INTO [dbo].[SystemSetting] ([ID], [SystemName], [SystemPicture], [Email], [smtpSeverName], [EmailName], [Emailpwd], [FileType], [IsIdentifyingCode]) VALUES (N'2', N'多多控校企合作项目管理软件', N'logo_white.png', N'whfwlf@qq.com', N'smtp.qq.com', N'hfwlf@qq.com', N'azpccpnzxfkbbgee', N' ', N'1')
GO

SET IDENTITY_INSERT [dbo].[SystemSetting] OFF
GO


-- ----------------------------
-- Table structure for SystemUser
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SystemUser]') AND type IN ('U'))
	DROP TABLE [dbo].[SystemUser]
GO

CREATE TABLE [dbo].[SystemUser] (
  [ID] int  IDENTITY(1,1) NOT NULL,
  [UserName] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [UserPwd] varchar(200) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [TrueName] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [RoleID] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [EmailStr] varchar(250) COLLATE Chinese_PRC_CI_AS  NULL,
  [Sex] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [BirthDay] varchar(50) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [MingZu] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [SFZSerils] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [XueLi] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [ZhiCheng] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [BiYeYuanXiao] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [ZhuanYe] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [CanJiaGongZuoTime] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [JiaRuBenDanWeiTime] varchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [photo] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [IsDelete] int  NULL,
  [DepartmentID] int  NOT NULL,
  [IsEnter] int  NOT NULL,
  [TelphoneNumber] nvarchar(50) COLLATE Chinese_PRC_CI_AS  NULL,
  [AddTime] datetime  NOT NULL,
  [AddPeople] varchar(255) COLLATE Chinese_PRC_CI_AS  NOT NULL,
  [loginCount] int DEFAULT ((0)) NOT NULL,
  [loginTime] datetime DEFAULT (getdate()) NOT NULL
)
GO

ALTER TABLE [dbo].[SystemUser] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'自动编号',
'SCHEMA', N'dbo',
'TABLE', N'SystemUser',
'COLUMN', N'ID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'用户名',
'SCHEMA', N'dbo',
'TABLE', N'SystemUser',
'COLUMN', N'UserName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'用户密码',
'SCHEMA', N'dbo',
'TABLE', N'SystemUser',
'COLUMN', N'UserPwd'
GO

EXEC sp_addextendedproperty
'MS_Description', N'真实姓名',
'SCHEMA', N'dbo',
'TABLE', N'SystemUser',
'COLUMN', N'TrueName'
GO

EXEC sp_addextendedproperty
'MS_Description', N'角色ID',
'SCHEMA', N'dbo',
'TABLE', N'SystemUser',
'COLUMN', N'RoleID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'邮箱地址',
'SCHEMA', N'dbo',
'TABLE', N'SystemUser',
'COLUMN', N'EmailStr'
GO

EXEC sp_addextendedproperty
'MS_Description', N'性别',
'SCHEMA', N'dbo',
'TABLE', N'SystemUser',
'COLUMN', N'Sex'
GO

EXEC sp_addextendedproperty
'MS_Description', N'生日',
'SCHEMA', N'dbo',
'TABLE', N'SystemUser',
'COLUMN', N'BirthDay'
GO

EXEC sp_addextendedproperty
'MS_Description', N'民族',
'SCHEMA', N'dbo',
'TABLE', N'SystemUser',
'COLUMN', N'MingZu'
GO

EXEC sp_addextendedproperty
'MS_Description', N'身份证号',
'SCHEMA', N'dbo',
'TABLE', N'SystemUser',
'COLUMN', N'SFZSerils'
GO

EXEC sp_addextendedproperty
'MS_Description', N'学历',
'SCHEMA', N'dbo',
'TABLE', N'SystemUser',
'COLUMN', N'XueLi'
GO

EXEC sp_addextendedproperty
'MS_Description', N'职称',
'SCHEMA', N'dbo',
'TABLE', N'SystemUser',
'COLUMN', N'ZhiCheng'
GO

EXEC sp_addextendedproperty
'MS_Description', N'毕业院校',
'SCHEMA', N'dbo',
'TABLE', N'SystemUser',
'COLUMN', N'BiYeYuanXiao'
GO

EXEC sp_addextendedproperty
'MS_Description', N'专业',
'SCHEMA', N'dbo',
'TABLE', N'SystemUser',
'COLUMN', N'ZhuanYe'
GO

EXEC sp_addextendedproperty
'MS_Description', N'参加工作时间',
'SCHEMA', N'dbo',
'TABLE', N'SystemUser',
'COLUMN', N'CanJiaGongZuoTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'加入本单位时间',
'SCHEMA', N'dbo',
'TABLE', N'SystemUser',
'COLUMN', N'JiaRuBenDanWeiTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'照片',
'SCHEMA', N'dbo',
'TABLE', N'SystemUser',
'COLUMN', N'photo'
GO

EXEC sp_addextendedproperty
'MS_Description', N'标记删除',
'SCHEMA', N'dbo',
'TABLE', N'SystemUser',
'COLUMN', N'IsDelete'
GO

EXEC sp_addextendedproperty
'MS_Description', N'部门ID',
'SCHEMA', N'dbo',
'TABLE', N'SystemUser',
'COLUMN', N'DepartmentID'
GO

EXEC sp_addextendedproperty
'MS_Description', N'是否允许登录：0允许：1不允许',
'SCHEMA', N'dbo',
'TABLE', N'SystemUser',
'COLUMN', N'IsEnter'
GO

EXEC sp_addextendedproperty
'MS_Description', N'电话号码',
'SCHEMA', N'dbo',
'TABLE', N'SystemUser',
'COLUMN', N'TelphoneNumber'
GO

EXEC sp_addextendedproperty
'MS_Description', N'添加时间',
'SCHEMA', N'dbo',
'TABLE', N'SystemUser',
'COLUMN', N'AddTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'添加人',
'SCHEMA', N'dbo',
'TABLE', N'SystemUser',
'COLUMN', N'AddPeople'
GO

EXEC sp_addextendedproperty
'MS_Description', N'登录次数',
'SCHEMA', N'dbo',
'TABLE', N'SystemUser',
'COLUMN', N'loginCount'
GO

EXEC sp_addextendedproperty
'MS_Description', N'最后登录时间',
'SCHEMA', N'dbo',
'TABLE', N'SystemUser',
'COLUMN', N'loginTime'
GO

EXEC sp_addextendedproperty
'MS_Description', N'系统用户',
'SCHEMA', N'dbo',
'TABLE', N'SystemUser'
GO


-- ----------------------------
-- Records of SystemUser
-- ----------------------------
SET IDENTITY_INSERT [dbo].[SystemUser] ON
GO

INSERT INTO [dbo].[SystemUser] ([ID], [UserName], [UserPwd], [TrueName], [RoleID], [EmailStr], [Sex], [BirthDay], [MingZu], [SFZSerils], [XueLi], [ZhiCheng], [BiYeYuanXiao], [ZhuanYe], [CanJiaGongZuoTime], [JiaRuBenDanWeiTime], [photo], [IsDelete], [DepartmentID], [IsEnter], [TelphoneNumber], [AddTime], [AddPeople], [loginCount], [loginTime]) VALUES (N'5', N'admin', N'E10ADC3949BA59ABBE56E057F20F883E', N'系统管理员', N'4', NULL, N'男', N'1985-12-29', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'1', N'1', N'0', N'18069772305', N'2020-10-15 14:55:22.000', N'系统管理员', N'0', N'2020-10-19 09:46:08.000')
GO

SET IDENTITY_INSERT [dbo].[SystemUser] OFF
GO


-- ----------------------------
-- Primary Key structure for table Contract
-- ----------------------------
ALTER TABLE [dbo].[Contract] ADD CONSTRAINT [PK__Contract__C1F8DC59EE610BA0] PRIMARY KEY CLUSTERED ([CID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Eenterprises
-- ----------------------------
ALTER TABLE [dbo].[Eenterprises] ADD CONSTRAINT [PK__Eenterpr__52DEA5469C8E5F11] PRIMARY KEY CLUSTERED ([EnterpriseID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Employee
-- ----------------------------
ALTER TABLE [dbo].[Employee] ADD CONSTRAINT [PK__Employee__C190170BF434D7FE] PRIMARY KEY CLUSTERED ([EID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Financial
-- ----------------------------
ALTER TABLE [dbo].[Financial] ADD CONSTRAINT [PK__Financia__C1BEA5A2550CFFD3] PRIMARY KEY CLUSTERED ([FID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table HFile
-- ----------------------------
ALTER TABLE [dbo].[HFile] ADD CONSTRAINT [PK__HFile__6F0F989F9F20AA6F] PRIMARY KEY CLUSTERED ([FileID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Invoice
-- ----------------------------
ALTER TABLE [dbo].[Invoice] ADD CONSTRAINT [PK__Invoice__D796AAD5F2DDBE1D] PRIMARY KEY CLUSTERED ([InvoiceID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Project
-- ----------------------------
ALTER TABLE [dbo].[Project] ADD CONSTRAINT [PK__Project__761ABED0EC730B33] PRIMARY KEY CLUSTERED ([ProjectID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

