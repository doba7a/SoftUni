import java.util.Scanner;

public class variableInHexFormat {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String hexNumber = scanner.next();
        System.out.println(Integer.parseInt(hexNumber, 16));
    }
}
