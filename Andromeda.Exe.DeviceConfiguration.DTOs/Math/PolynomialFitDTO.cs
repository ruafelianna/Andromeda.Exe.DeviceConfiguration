namespace Andromeda.Exe.DeviceConfiguration.DTOs.Math
{
    public record PolynomialFitDTO(
        double[] X,
        double[] Y,
        int Degree
    );
}
