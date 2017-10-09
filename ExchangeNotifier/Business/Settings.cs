using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ErikvO.ExchangeNotifier.Business
{
	public static class Settings
	{
		private const string SETTINGSFILENAME = "ExchangeNotifierSettings.bin";

		public static MonitoredMailboxCollection LoadSettings()
		{
			if (File.Exists(SETTINGSFILENAME))
			{
				BinaryFormatter formatter = new BinaryFormatter();
				using (FileStream fileStream = File.OpenRead(SETTINGSFILENAME))
				{
					return (MonitoredMailboxCollection)formatter.Deserialize(fileStream);
				}
			}
			else
				return new MonitoredMailboxCollection();
		}

		public static void SaveSettings(MonitoredMailboxCollection mailboxes)
		{
			BinaryFormatter formatter = new BinaryFormatter();
			using (FileStream fileStream = File.Create(SETTINGSFILENAME))
			{
				formatter.Serialize(fileStream, mailboxes);
			}
		}
	}
}