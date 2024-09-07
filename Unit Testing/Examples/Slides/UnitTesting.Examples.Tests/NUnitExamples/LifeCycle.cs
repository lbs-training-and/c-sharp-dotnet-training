namespace UnitTesting.Examples.Tests;

[SetUpFixture]
public class Setup
{
    [OneTimeSetUp]
    public void SetUp() => TestContext.Progress.WriteLine("OneTimeSetUp");
    
    [OneTimeTearDown]
    public void TearDown() => TestContext.Out.WriteLine("OneTimeTearDown");
}

[TestFixture]
public class TestsA
{
    [SetUp]
    public void Setup() => TestContext.WriteLine("TestsASetUp");

    [Test]
    public void Test1() => TestContext.WriteLine("TestA1");

    [Test]
    public void Test2() => TestContext.Out.WriteLine("TestA2");

    [TearDown]
    public void TearDown() => TestContext.WriteLine("TestsATearDown");
}

[TestFixture]
public class TestsB
{
    [Test]
    public void Test1() => TestContext.WriteLine("TestB1");

    [Test]
    public void Test2() => TestContext.WriteLine("TestB2");
}