using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YungBudaAPI.Migrations
{
    /// <inheritdoc />
    public partial class InsertigData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Phrases(Artist,Phrase,SongName,Album,UrlAlbumCover) " +
                "Value('Yung Buda','Rejeite falsos ícones, segue Yung Buda 7K','Rejeite Falsos Icones'," +
                "'Músicas para Drift, Vol.III','https://akamai.sscdn.co/uploadfile/letras/albuns/1/7/6/3/1153881631883111.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Phrases");
        }
    }
}
