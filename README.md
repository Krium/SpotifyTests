# SpotifyTests
For this task, use the Selenium WebDriver, framework unit test parameterization, Page Object Model. Launch the Spotify Url "https://open.spotify.com/" and the use case to automate would be Login functionality.

UC -1 - Test Login form with empty credentials:

Type any credentials

Clear the inputs.

Check the error messages:

3.1 Please enter your Spotify username or email address.

3.2 Please enter your password.

UC-2 - Test Login form with incorrect credentials:

Type any incorrect credentials and click LOG IN button. X.

Check the error message:

2.1 Incorrect username or password.t

UC -3 - Test Login form with correct credentials:

Type correct credentials and click LOG IN button.
Check that Name is correct.
Provide parallel execution, add logging for test s and use Data Provider to parametrize tests. Make sure that all tasks supported by this 3 conditions: 1. UC - 1; 2. UC - 2; 3. UC -3.

