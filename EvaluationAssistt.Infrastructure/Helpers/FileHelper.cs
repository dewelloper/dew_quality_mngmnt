using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;

namespace EvaluationAssistt.Infrastructure.Helpers
{
    public class FileHelper
    {
        public static string GetFilePath(string fileName)
        {
            var settings = WebConfigurationManager.AppSettings;
            var soundFilePath = settings["SoundFilePath"].ToString();

            var longFileName = fileName;
            var file_Name = Convert.ToInt64(fileName.Split('-')[0]);
            var fileTime = new DateTime(file_Name);
            var Path = soundFilePath + fileTime.ToString("yyyy") + "/" + fileTime.ToString("MM") + "/" + fileTime.ToString("dd") + "/" + fileTime.ToString("HH") + "/" + longFileName + ".mp3";

            return Path;
        }

        public static string GetSoundPlayer(string voiceRecordURL)
        {
            var script = "<audio controls>"
              + "<source src='" + voiceRecordURL + "' type='audio/mpeg'/>"
              + "<source src='" + voiceRecordURL + "' type='audio/ogg'/>"
              + "<source src='" + voiceRecordURL + "' type='audio/mp3'> "
              + "<source src='" + voiceRecordURL + "' type='audio/ogg'> "
              + "<source src='" + voiceRecordURL + "' type='audio/mp4'> "
              + "<object type='application/x-shockwave-flash' data='" + WebConfigurationManager.AppSettings["SoundFileIp"].ToString() + "/Scripts/OriginalMusicPlayer.swf' width='225' height='86'> "
              + "<param name='movie' value='" + WebConfigurationManager.AppSettings["SoundFileIp"].ToString() + "/Scripts/OriginalMusicPlayer.swf'/>"
              + "<param name='FlashVars' value='mediaPath=" + voiceRecordURL + "' /> "
              + "</object> "
            + "</audio>";
            return script;
        }
    }
}
