CREATE DATABASE zapper;

CREATE TABLE Mechants (
    
    MerchantId bigint not null,
    MerchantName varchar(100) not null,
    MerchantAddress varchar(255),
    MerchantEmail varchar(100),
    MerchantPhoneNumber varchar(20),

    PRIMARY_KEY (MerchantId)
)

CREATE TABLE ZapperUsers (
    
    UserId bigint not null,
    UserName varchar(100) not null,
    UserAddress varchar(255),
    UserEmail varchar(100),
    UserPhoneNumber varchar(20),

    PRIMARY_KEY (UserId)
)

CREATE TABLE AuthStatus (
    
    StatusId int not null,
    StatusDescription varchar(100) not null,

    PRIMARY_KEY (StatusId)
)

CREATE TABLE CompletionStatus (
    
    StatusId int not null,
    StatusDescription varchar(100) not null,

    PRIMARY_KEY (StatusId)
)

-- Note that Amounts are in a minor denomintaions (cents)
CREATE TABLE ZapperTransactions (

    TranId bigint not null,
    TranUuid varchar(36), -- UUID Variant 7 Reference for external lookups
    TranDate date,
    TranTime time,
    TranAmountExlVat bigint not null, 
    TranAmountVat bigint not null, 
    TranAmountInclVat bigint not null, 
    TranAmountServiceFee bigint not null, 
    MerchantId bigint not null,
    MerchantRequestReference varchar(36) not null,
    UserId bigint not null,
    TranAuthStatus int not null,
    TranCompletionStatus int not null,
    TranDescription varchar(100),

    PRIMARY_KEY (TranId),
    FOREIGN KEY (MerchantId) REFERENCES Mechants(MerchantId),
    FOREIGN KEY (UserId) REFERENCES ZapperUsers(UserId),
    FOREIGN KEY (TranAuthStatus) REFERENCES AuthStatus(StatusId),
    FOREIGN KEY (TranCompletionStatus) REFERENCES CompletionStatus(StatusId)
)