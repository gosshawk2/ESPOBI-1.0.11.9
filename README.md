# ESPOBI-1.0.11.9
ESPOBI DG SQLBuilder tool. Last update Oct2021
Will need to create a mysql / ibm database called: simplequerydatabase
Table: ebi7020t: DatasetID INT,DatasetName VARCHAR,DatasetHeaderText VARCHAR, TableName VARCHAR, AuthorityFlag INT, CRTuserID VARCHAR,CRTTIMESTAMP DATETIME,UPDUserID VARCHAR,UPDTimestamp DATETIME
CREATE TABLE IF NOT EXISTS `ebi7023t` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `DataSetID` int(11) NOT NULL DEFAULT 0,
  `DataSetName` varchar(20) NOT NULL,
  `Sequence` int(11) NOT NULL DEFAULT 0,
  `TableName` varchar(20) NOT NULL,
  `ColumnName` varchar(30) NOT NULL,
  `ColumnText` varchar(30) NOT NULL,
  `ColumnType` varchar(10) DEFAULT NULL,
  `ColumnLength` int(11) DEFAULT NULL,
  `ColumnDecimals` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=52 DEFAULT CHARSET=utf8mb4;
