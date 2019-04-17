interface TransactionServiceConfig {
    Auth: string;
    apiEndpoint: string;
    callbackURL: string;
  }

  export const TRANSACTIONSERVICE_CONFIG: TransactionServiceConfig = {
    Auth: 'U2FtcGxlVXNlcjpzZWNyZXQ=',
    apiEndpoint: 'http://localhost:63755/api/v1/', // 'http://localhost/SimpleLedger.Account/api/v1/account/'
    callbackURL: 'http://localhost:4200/callback'
  };
  