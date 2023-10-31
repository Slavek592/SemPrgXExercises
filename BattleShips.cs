namespace Solution {
  using System;
  public class BattleshipField {
    public static int GetLength(int[,] field, (int x, int y) place, int direction, int length)
    {
      if (direction == 0)
      {
        int x = 0;
        int y = 0;
        for (int i = 1; i < 5; i++)
        {
          int test = GetLength(field, place, i, 0);
          if (test == -1) return -1;
          if (i % 2 == 0) y += test;
          else x += test;
        }
        if (x > 0 && y > 0)
          return -1;
        return Math.Max(x, y) + 1;
      }
      else if (direction == 1)
      {
        if (length > 0)
        {
          if (place.y != 0 && field[place.x, place.y-1] == 1) return -1;
          if (place.y != 9 && field[place.x, place.y+1] == 1) return -1;
        }
        if (place.x == 0) return length;
        else if (field[place.x-1,place.y] == 1)
          return GetLength(field, (place.x-1, place.y), direction, length + 1);
        else
        {
          if (length > 0)
          {
            if (place.y != 0 && field[place.x-1, place.y-1] == 1) return -1;
            if (place.y != 9 && field[place.x-1, place.y+1] == 1) return -1;
          }
          return length;
        }
      }
      else if (direction == 2)
      {
        if (length > 0)
        {
          if (place.x != 0 && field[place.x-1, place.y] == 1) return -1;
          if (place.x != 9 && field[place.x+1, place.y] == 1) return -1;
        }
        if (place.y == 0) return length;
        else if (field[place.x,place.y-1] == 1)
          return GetLength(field, (place.x, place.y-1), direction, length + 1);
        else
        {
          if (length > 0)
          {
            if (place.x != 0 && field[place.x-1, place.y-1] == 1) return -1;
            if (place.x != 9 && field[place.x+1, place.y-1] == 1) return -1;
          }
          return length;
        }
      }
      else if (direction == 3)
      {
        if (length > 0)
        {
          if (place.y != 0 && field[place.x, place.y-1] == 1) return -1;
          if (place.y != 9 && field[place.x, place.y+1] == 1) return -1;
        }
        if (place.x == 9) return length;
        else if (field[place.x+1,place.y] == 1)
          return GetLength(field, (place.x+1, place.y), direction, length + 1);
        else
        {
          if (length > 0)
          {
            if (place.y != 0 && field[place.x+1, place.y-1] == 1) return -1;
            if (place.y != 9 && field[place.x+1, place.y+1] == 1) return -1;
          }
          return length;
        }
      }
      else if (direction == 4)
      {
        if (length > 0)
        {
          if (place.x != 0 && field[place.x-1, place.y] == 1) return -1;
          if (place.x != 9 && field[place.x+1, place.y] == 1) return -1;
        }
        if (place.y == 9) return length;
        else if (field[place.x,place.y+1] == 1)
          return GetLength(field, (place.x, place.y+1), direction, length + 1);
        else
        {
          if (length > 0)
          {
            if (place.x != 0 && field[place.x-1, place.y+1] == 1) return -1;
            if (place.x != 9 && field[place.x+1, place.y+1] == 1) return -1;
          }
          return length;
        }
      }
      else return -1;
    }
    public static bool ValidateBattlefield(int[,] field) {
      int[] ships = {0, 0, 0, 0};
      for (int i = 0; i < 10; i++)
      {
        for (int j = 0; j < 10; j++)
        {
          if (field[i,j] == 1)
          {
            int test = GetLength(field, (i,j), 0, 0);
            if (test == -1) return false;
            ships[test-1] ++;
          }
        }
      }
      if (ships[0] != 4 || ships[1] != 6 || ships[2] != 6 || ships[3] != 4) return false;
      return true;
    }
  }
}
