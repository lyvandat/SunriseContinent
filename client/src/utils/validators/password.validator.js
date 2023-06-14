
/**
 * Check if the provided password is valid.
 * @param {string} password - The password to validate.
 * @returns {boolean} True if the password is valid, false otherwise.
 */
export function isValidPassword(password) {
    // Password validation rules:
    // - At least 6 characters long
    const passwordRegex = /^.{6,}$/;
    return passwordRegex.test(password);

}