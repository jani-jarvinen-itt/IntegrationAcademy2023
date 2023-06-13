import unittest


def laske_summa(a, b):
    return a + b


class TestaaSummanLaskenta(unittest.TestCase):

    def test_summa_1(self):
        self.assertEqual(46, laske_summa(12, 34))

    def test_summa_2(self):
        self.assertEqual(13, laske_summa(-10, 23))


if __name__ == '__main__':
    unittest.main()
