using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TicTacToe.Domain;

namespace TicTacToe.Persistence.EntityConfigurations
{
    internal class GameTableConfiguration : IEntityTypeConfiguration<GameTable>
    {
        public void Configure(EntityTypeBuilder<GameTable> builder)
        {
            builder.HasKey(note => note.Id);
            builder.HasIndex(note => note.Id).IsUnique();
        }
    }
}
