// Import necessary modules and hooks
import { BROADCAST_MESSAGE } from "../../constants.js";
import { useRegisterMutation } from "../../fetching/mutation.js";
import { useAccessToken } from "./useAccessToken.js";
import { useAuthBroadcastChannel } from "./useAuthBroadcastChannel.js";

const isRememberMeDefault = false;
const failMessage = "Registration failed";
// Define useRegister hook
export const useRegister = () => {
  const { postMessage } = useAuthBroadcastChannel();
  const { setToken } = useAccessToken();
  // Define mutation for register function with retry and success/error handlers
  const registerMutation = useRegisterMutation();

  // Define onRegister function to handle registration
  const onRegister = (email, password) => {
    return new Promise((resolve, reject) => {
      registerMutation
        .mutateAsync({email, password})
        .then((response) => {
          // On success, if token is present, store it in session storage and update context

          if (response.statusCode === 200 && response.token) {
            setToken(response.token, isRememberMeDefault);
            postMessage({
              message: BROADCAST_MESSAGE.SEND_TOKEN,
              token: response.token,
              isRemember: isRememberMeDefault
            });
            resolve({
              statusCode: response.statusCode,
              message: response.message
            });
          } else {
            reject({
              statusCode: response.statusCode,
              message: failMessage
            });
          }
        })
        .catch((error) => {
          reject(error);
        });
    });
  };

  // Return onRegister function and loading status
  return {
    onRegister,
    isLoading: registerMutation.isLoading
  };
};
