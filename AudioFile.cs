namespace Fourier
{
    public class AudioFile
    {
        public sbyte[] Buffer { get; set; }

        public AudioFile(
            sbyte[] buffer
        )
        {
            Buffer =
                buffer;
        }

        public static AudioFile Import(
            byte[] source
        )
        {
            using var stream =
                new MemoryStream();

            var reader =
                new BinaryReader(
                    stream
                );

            var bufferSize =
                reader.ReadInt32();
            var buffer =
                reader
                    .ReadBytes(
                        bufferSize
                    )
                    .Select(
                        x =>
                            (sbyte)x
                    )
                    .ToArray();

            return new AudioFile(
                buffer
            );
        }

        public byte[] Export()
        {
            using var stream =
                new MemoryStream();

            var writer =
                new BinaryWriter(
                    stream
                );

            writer.Write(
                Buffer.Length
            );
            writer.Write(
                Buffer
                    .Select(
                        x =>
                            (byte)x
                    )
                    .ToArray(),
                0,
                Buffer.Length
            );

            return stream.GetBuffer();
        }
    }
}
