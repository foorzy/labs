import sys
import argparse
import os
import shutil
import glob
from os.path import getsize, join

def createParser ():
	parser = argparse.ArgumentParser()
	parser.add_argument ('-R', action = 'store_true', help = 'Vkluchenie rekursii')
	parser.add_argument ('-D', nargs = 1, type = str, help = 'Vvod directoriyi')
	parser.add_argument ('ext', nargs='*', help = 'Spisok masok')
	return parser

if __name__ == '__main__':
	parser = createParser()
	args = parser.parse_args(sys.argv[1:])
	
	if args.D:
		for dir in args.D:
			if os.path.exists(dir):
				path = dir
			else:
				print("Takoi directoriyi {} ne suwestvuet.".format(dir))
				sys.exit(j)
	else:
		path = os.path.dirname(os.path.abspath(__file__))		
	if args.R:
		j = 0
		count = 0
		for rootdir, dirs, files in os.walk(path):
					for file in files:
						if len(args.ext) == 0:
							fp = os.path.join(rootdir, file)
							j = j + os.path.getsize(fp)
							count = count + 1
						else:
							k = 0
							for i in args.ext:
								if i in file:
									k = 1
							if k == 1:
								fp = os.path.join(rootdir, file)
								j = j + os.path.getsize(fp)
								count = count + 1
	else:
		j = 0
		count = 0
		for rootdir, dirs, files in os.walk(path):
			for file in files:
				if rootdir == path:
						if len(args.ext) == 0:
							fp = os.path.join(rootdir, file)
							j = j + os.path.getsize(fp)
							count = count + 1
						else:
							k = 0
							for i in args.ext:
								if i in file:
									k = 1
							if k == 1:
								fp = os.path.join(rootdir, file)
								j = j + os.path.getsize(fp)
								count = count + 1
	print("Failov naydeno - {}".format(count))							
	print("Ob'em failov - {}".format(j))
	sys.exit(j)
	input()
