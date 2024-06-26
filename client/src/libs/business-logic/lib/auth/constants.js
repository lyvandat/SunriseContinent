export const SESSION_STORAGE_KEY = {
  ACCESS_TOKEN: "SESSION_STORAGE_KEY_ACCESS_TOKEN"
};
export const COOKIE_KEY = {
  ACCESS_TOKEN: "COOKIE_KEY_ACCESS_TOKEN"
};
export const LOCAL_STORAGE_KEY = {
  IS_REMEMBER: "LOCAL_STORAGE_KEY_IS_REMEMBER"
};
export const CONTEXT_ACTION = {
  GET_ACTION: "CONTEXT_ACTION_GET_ACCESS_TOKEN",
  SET_ACTION: "CONTEXT_ACTION_SET_ACCESS_TOKEN"
};
export const BROADCAST_MESSAGE = {
  NEED_TOKEN: "BROADCAST_MESSAGE_NEED_TOKEN",
  SEND_TOKEN: "BROADCAST_MESSAGE_SEND_TOKEN",
  NEED_LOGOUT: "BROADCAST_MESSAGE_NEED_LOGOUT"
};
export const TOKEN_EXPIRY_DAYS = {
  NON_REMEMBER: 2,
  REMEMBER: 30
};
export const MUTATION_CONFIG = {
  RETRY_TIMES: 0
};
export const QUERY_KEYS = {
  VALIDATE_TOKEN: "QUERY_KEYS_VALIDATE_TOKEN",
  GET_ACCOUNT_INFO: "QUERY_KEYS_GET_ACCOUNT_INFO"
}
export const BROADCAST_CHANNEL = {
  AUTH_CHANNEL: "BROADCAST_CHANNEL_AUTHENTICATION_CHANNEL"
};
//TODO: move on .env
export const GOOGLE_CONFIG = {
  CLIENT_ID: '490941492727-9ojv2i4jejj7ni0a6nt8go90cmiebgb2.apps.googleusercontent.com',
  CLIENT_SECRET: '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',
  PROJECT_ID: 'invoker-392013',
  AUTH_URI: 'https://accounts.google.com/o/oauth2/auth',
  TOKEN_URI: 'https://oauth2.googleapis.com/token',
  AUTH_PROVIDER_X509_CERT_URL: 'https://www.googleapis.com/oauth2/v1/certs',
  REDIRECT_URI: 'http://localhost:4200',
  JAVASCRIPT_ORIGIN: 'http://localhost:4200',
  SCOPE: 'https://www.googleapis.com/auth/userinfo.email https://www.googleapis.com/auth/userinfo.profile'
}
export const GOOGLE_MESSAGE = {
  GOOGLE_LOGIN_SUCCESS: 'GOOGLE_MESSAGE_GOOGLE_LOGIN_SUCCESS',
  GOOGLE_LOGIN_FAILED: 'GOOGLE_MESSAGE_GOOGLE_LOGIN_FAILED'
}
