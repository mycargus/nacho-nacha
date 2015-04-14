using FluentAssertions;
using TypeMock.ArrangeActAssert;
using Xunit;

namespace Nacha.Core.UnitTests
{
    [Isolated]
    public class BatchTests 
    {
	    [Fact]
	    public void Batch_NewBatchIsCreated_NumberOfBatchesCreatedIncrementsByOne()
	    {
		    // arrange
		    var batch = Isolate.Fake.Dependencies<Batch>();
		    const int ExpectedResultNumberOfBatches = 1;

		    // act
		    var resultNumberOfBatches = Batch.BatchCount;

		    // assert
		    resultNumberOfBatches.Should()
			    .Be(ExpectedResultNumberOfBatches,
				    "total count of batches should increment by 1 when a new batch is created");
	    }

	    



	    //[Fact]
	    //public void Batch_NewBatchIsCreated_NumberOfBatchesCreatedEqualsNumberOfBatchesInNachaFile()
	    //{
	    //	// arrange
	    //	//Batch batch = Isolate.Fake.Dependencies<Batch>();
	    //	//List<Batch> a_Batches = new List<Batch> { batch };

	    //	// act
	    //	NachaFile file = Isolate.Fake.Dependencies<NachaFile>();
	    //	int resultNumberOfBatches = Batch.BatchCount;
		    

	    //	// assert
	    //	file.BatchCount.Should().Be(resultNumberOfBatches, "all created Batch objects should be added to the Nacha file");
	    //}

    }
}
