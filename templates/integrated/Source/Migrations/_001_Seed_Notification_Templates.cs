using Dom;
using MyProject;

namespace Migrations;

internal sealed class _001_Seed_Notification_Templates : IMigration
{
    public async Task UpgradeAsync()
    {
        await new[] {
            new NotificationTemplate
            {
                ID = NotificationType.MemberWelcome,
                EmailSubject = "Please validate your account {Salutation}...",
                EmailBody = """
                            <html>
                                <body>
                                    <div>
                                        <table border='0' width='550' cellpadding='0' cellspacing='0' style='max-width:550px;border-top:4px solid #39c;font:12px arial,sans-serif;margin:0 auto'>
                                            <tbody>
                                            <tr>
                                                <td>
                                                    <h1 style='color:#000;font:bold 23px arial;margin:5px 0'>
                                                        <span style='color:rgb(74,176,156);font-family:-apple-system,BlinkMacSystemFont,Segoe UI,Roboto,Oxygen-Sans,Ubuntu,Cantarell,Helvetica Neue,sans-serif;font-size:35px;font-weight:400'>
                                                            MongoWebApiStarter
                                                        </span>
                                                    </h1>
                                                    <p style='font-family:Arial,Helvetica,sans-serif;font-size:small'>
                                                        Thank you for creating an account on our system.</p>
                                                    <p style='font-family:Arial,Helvetica,sans-serif;font-size:small'>
                                                        <strong style='font-family:Roboto,RobotoDraft,Helvetica,Arial,sans-serif;font-size:12px'>
                                                            <a href='{ValidationLink}' target='_blank'>Click here</a>
                                                        </strong>
                                                        <span style='font-family:Roboto,RobotoDraft,Helvetica,Arial,sans-serif;font-size:12px'>
                                                            to confirm your email address.</span>
                                                    </p>
                                                    <p>If the above link does not work, you can paste the following address into your browser:</p>
                                                    <p>{ValidationLink}</p>
                                                    <p>This is the address you will log in with, and the address to which we will deliver all email messages and other system mail.</p>
                                                    <p>Thank you for using MongoWebApiStarter!</p>
                                                    <p>
                                                        --The MongoWebApiStarter Team<br>
                                                        <a href='https://MyProject.com' target='_blank'>https://MyProject.com</a>
                                                    </p>
                                                    <p style='margin:3px auto;font:10px arial,sans-serif;color:#999'>© 2023 Copyright</p>
                                                </td>
                                            </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </body>
                            </html>
                            """,
                SmsBody = "Thank you for creating an account {Salutation}. Please check your email and click the verification link in order to activate your account."
            },
            new NotificationTemplate
            {
                ID = NotificationType.ReviewNewMember,
                EmailSubject = "A new member has signed up.",
                EmailBody = """
                            <html>
                                <body>
                                    <div>
                                        <table border='0' width='550' cellpadding='0' cellspacing='0' style='max-width:550px;border-top:4px solid #39c;font:12px arial,sans-serif;margin:0 auto'>
                                            <tbody>
                                            <tr>
                                                <td>
                                                    <h1 style='color:#000;font:bold 23px arial;margin:5px 0'>
                                                        <span style='color:rgb(74,176,156);font-family:-apple-system,BlinkMacSystemFont,Segoe UI,Roboto,Oxygen-Sans,Ubuntu,Cantarell,Helvetica Neue,sans-serif;font-size:35px;font-weight:400'>
                                                            MyProject
                                                        </span>
                                                    </h1>
                                                    <p style='font-family:Arial,Helvetica,sans-serif;font-size:small'>
                                                        A new member has signed up: <b>{MemberName}</b></p>
                                                    <p style='font-family:Arial,Helvetica,sans-serif;font-size:small'>
                                                        Please review the application by <a href="{LoginLink}">signing in</a>.
                                                    </p>
                                                    <p style='margin:3px auto;font:10px arial,sans-serif;color:#999'>© 2024 Copyright</p>
                                                    <div style="visibility:hidden">{TrackingId}</div>
                                                </td>
                                            </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </body>
                            </html>
                            """,
                SmsBody = "A new member [{MemberName}] has signed up on MyProject. Please review!"
            }
        }.SaveAsync();
    }
}