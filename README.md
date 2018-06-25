# Usage
**Add library to your project:**
``` powershell
PM> Install-Package AnticaptchaNet
```

**And simply:**
```cs
Anticaptcha anticaptcha = new Anticaptcha("YOUR_ANTICAPTCHA_KEY");

int taskId = anticaptcha.CreateTask("captcha_filepath.jpg");

var taskResult = new JsonApiResponse.AnticaptchaTaskResult();

while (!taskResult.IsDone)
	taskResult = anticaptcha.GetTaskResult(taskId);

string captchaSolution = taskResult.Solution.Text;
```

# Dependencies
- [Newtonsoft.Json](https://www.newtonsoft.com/)
- [JsonRequest](https://github.com/ademargomes/JsonRequest)