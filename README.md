# Usage
**Add library to your project:**
``` powershell
PM> Install-Package AnticaptchaNet
```

**And simply:**
```cs
Anticaptcha anticaptcha = new Anticaptcha("YOUR_ANTICAPTCHA_KEY");

if (anticaptcha.Balance < 0.1) return;

int taskId = anticaptcha.CreateTask("captcha_filepath.jpg");

TaskResult taskResult = anticaptcha.GetTaskResult(taskId);

while (!taskResult.IsDone)
{
    taskResult = anticaptcha.GetTaskResult(taskId);
    Thread.Sleep(1000); // Wait for captcha solution.
}

string captchaSolution = ((Captcha.ImageToTextSolution)taskResult.Solution).Text;
```

## Dependencies
- [Newtonsoft.Json](https://www.newtonsoft.com/)