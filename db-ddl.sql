CREATE DATABASE zapper;

CREATE TABLE mechants (
    
    MerchantId bigint not null,
    MerchantName varchar(100) not null,
    MerchantAddress varchar(255),

    PRIMARY_KEY (MerchantId)
)

CREATE TABLE users (
    
    UserId bigint not null,
    UserName varchar(100) not null,
    UserAddress varchar(255),

    PRIMARY_KEY (UserId)
)

CREATE TABLE auth_status (
    
    StatusId int not null,
    StatusDescription varchar(100) not null,

    PRIMARY_KEY (StatusId)
)

CREATE TABLE completion_status (
    
    StatusId int not null,
    StatusDescription varchar(100) not null,

    PRIMARY_KEY (StatusId)
)

-- Note that Amounts are in a minor denomintaions (cents)
CREATE TABLE zapper_transactions (

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
    FOREIGN KEY (MerchantId) REFERENCES mechants(MerchantId),
    FOREIGN KEY (UserId) REFERENCES users(UserId),
    FOREIGN KEY (TranAuthStatus) REFERENCES auth_status(StatusId),
    FOREIGN KEY (TranCompletionStatus) REFERENCES completion_status(StatusId)
)