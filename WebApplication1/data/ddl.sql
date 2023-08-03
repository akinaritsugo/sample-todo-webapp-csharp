DROP TABLE IF EXISTS TaskMetaInfo;
DROP TABLE IF EXISTS Tags;
DROP TABLE IF EXISTS Tasks;
DROP TABLE IF EXISTS Users;

-- ユーザーテーブルを作成
CREATE TABLE Users (
    UserId INT IDENTITY(1, 1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL,
    EmailAddress NVARCHAR(100) NOT NULL,
    Password NVARCHAR(100) NOT NULL,
    OtherUserInfo NVARCHAR(255)
);

-- タスクテーブルを作成
CREATE TABLE Tasks (
    TaskId INT IDENTITY(1, 1) PRIMARY KEY,
    Title NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    Deadline DATETIME,
    Priority NVARCHAR(20),
    Status NVARCHAR(20),
    UserId INT NOT NULL,  -- UsersテーブルのUserIdと関連付ける外部キー
    FOREIGN KEY (UserId) REFERENCES Users (UserId)
);

-- タグテーブルを作成
CREATE TABLE Tags (
    TagId INT IDENTITY(1, 1) PRIMARY KEY,
    TagName NVARCHAR(50) NOT NULL
);

-- タスクとタグの関連テーブルを作成
CREATE TABLE TaskMetaInfo (
    TaskId INT NOT NULL,  -- TasksテーブルのTaskIdと関連付ける外部キー
    TagId INT NOT NULL,   -- TagsテーブルのTagIdと関連付ける外部キー
    PRIMARY KEY (TaskId, TagId),
    FOREIGN KEY (TaskId) REFERENCES Tasks (TaskId),
    FOREIGN KEY (TagId) REFERENCES Tags (TagId)
);
