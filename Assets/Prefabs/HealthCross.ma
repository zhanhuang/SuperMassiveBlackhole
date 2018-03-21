//Maya ASCII 2018 scene
//Name: HealthCross.ma
//Last modified: Wed, Mar 21, 2018 04:27:03 AM
//Codeset: 1252
requires maya "2018";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2018";
fileInfo "version" "2018";
fileInfo "cutIdentifier" "201706261615-f9658c4cfc";
fileInfo "osv" "Microsoft Windows 8 Home Premium Edition, 64-bit  (Build 9200)\n";
createNode transform -s -n "persp";
	rename -uid "A05EDFDF-4958-9FE7-4529-E2BC7207FD9C";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 11.462829811738766 4.9598564244161789 18.31646715144494 ;
	setAttr ".r" -type "double3" -18.338352729501608 36.200000000001069 0 ;
createNode camera -s -n "perspShape" -p "persp";
	rename -uid "6F9722DD-4784-45E5-9E9A-4BBC30AF4891";
	setAttr -k off ".v" no;
	setAttr ".fl" 34.999999999999986;
	setAttr ".ncp" 0.001;
	setAttr ".coi" 22.325253310559294;
	setAttr ".imn" -type "string" "persp";
	setAttr ".den" -type "string" "persp_depth";
	setAttr ".man" -type "string" "persp_mask";
	setAttr ".tp" -type "double3" -2.5809667073341163 -1.796656907790537 1.5633641057287524 ;
	setAttr ".hc" -type "string" "viewSet -p %camera";
createNode transform -s -n "top";
	rename -uid "2A3F6179-4556-3CF0-D5AA-838AA0A7D92E";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 100.23370700742238 4.95887966468585 ;
	setAttr ".r" -type "double3" -89.999999999999986 0 0 ;
createNode camera -s -n "topShape" -p "top";
	rename -uid "BCEFAF73-4A35-B9FC-3B9F-1A83655CE1AD";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".ncp" 0.001;
	setAttr ".coi" 100.1;
	setAttr ".ow" 3.0966150866450413;
	setAttr ".imn" -type "string" "top";
	setAttr ".den" -type "string" "top_depth";
	setAttr ".man" -type "string" "top_mask";
	setAttr ".hc" -type "string" "viewSet -t %camera";
	setAttr ".o" yes;
createNode transform -s -n "front";
	rename -uid "78505991-4447-554F-D400-158ACAD8D9F5";
	setAttr ".v" no;
	setAttr ".t" -type "double3" -2.835650643741114 -1.3653094401928341 100.15091423831939 ;
createNode camera -s -n "frontShape" -p "front";
	rename -uid "2489CCB8-4406-3F06-F7A0-1A8F9439B07F";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".ncp" 0.001;
	setAttr ".coi" 100.1;
	setAttr ".ow" 1.0872232971013018;
	setAttr ".imn" -type "string" "front";
	setAttr ".den" -type "string" "front_depth";
	setAttr ".man" -type "string" "front_mask";
	setAttr ".hc" -type "string" "viewSet -f %camera";
	setAttr ".o" yes;
createNode transform -s -n "side";
	rename -uid "EA1E0E42-4F21-8A08-3810-2DAEB981C3C2";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 100.10313168781559 -1.5372396573366309 0.17286884868272628 ;
	setAttr ".r" -type "double3" 0 89.999999999999986 0 ;
createNode camera -s -n "sideShape" -p "side";
	rename -uid "5EFEEF92-495D-63B2-DF70-E78BCE879391";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".ncp" 0.001;
	setAttr ".coi" 100.1;
	setAttr ".ow" 1.9120366937249595;
	setAttr ".imn" -type "string" "side";
	setAttr ".den" -type "string" "side_depth";
	setAttr ".man" -type "string" "side_mask";
	setAttr ".hc" -type "string" "viewSet -s %camera";
	setAttr ".o" yes;
createNode transform -n "pTorus1";
	rename -uid "CE768AAE-4761-FB96-3903-FB9D6DBC0753";
	setAttr ".r" -type "double3" 90 0 0 ;
	setAttr ".s" -type "double3" 1.9861372391367424 1.9861372391367424 1.9861372391367424 ;
createNode transform -n "transform2" -p "pTorus1";
	rename -uid "A71DCA9E-4FDF-A83C-C201-6DAC968EC524";
	setAttr ".v" no;
createNode mesh -n "pTorusShape1" -p "transform2";
	rename -uid "F6813A07-4E53-BFA5-4B92-2E852E689DCE";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr -s 2 ".iog[0].og";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ugsdt" no;
createNode transform -n "pCube1";
	rename -uid "B5730CDF-4FF6-2707-834C-15AD957C9FFA";
	setAttr ".s" -type "double3" 0.57234781165732107 0.57234781165732107 0.57234781165732107 ;
createNode transform -n "transform1" -p "pCube1";
	rename -uid "DE26992D-485D-228C-0A5E-D292C8954B1B";
	setAttr ".v" no;
createNode mesh -n "pCubeShape1" -p "transform1";
	rename -uid "8BADFDB1-4D39-D7B4-74AB-6987E3723142";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr -s 2 ".iog[0].og";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ugsdt" no;
createNode transform -n "polySurface1";
	rename -uid "9439D176-4EFD-6515-6E1B-0EB79DF60306";
createNode mesh -n "polySurfaceShape1" -p "polySurface1";
	rename -uid "C5069723-4F8B-23FB-70D2-1BA375D5A3D6";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ugsdt" no;
createNode transform -n "pCube2";
	rename -uid "1B2733E9-4134-B3E9-01D6-63A620440194";
createNode mesh -n "pCubeShape2" -p "pCube2";
	rename -uid "C41BA47E-458F-888C-535F-40885BCF34EA";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ugsdt" no;
	setAttr ".dr" 1;
createNode transform -n "pCube3";
	rename -uid "8F00AAD7-41DC-B44C-4CCB-E08635A5F26C";
createNode mesh -n "pCubeShape3" -p "pCube3";
	rename -uid "7EDF5AC3-408F-511B-6AA8-1DBA602C6CF7";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ugsdt" no;
	setAttr ".dr" 1;
createNode mesh -n "polySurfaceShape2" -p "pCube3";
	rename -uid "477B4DF4-47A0-6A66-02A4-A383C2EFA2AE";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 20 ".uvst[0].uvsp[0:19]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25 0.5 0.125 0.5 0.375 0.5 0.625 0.5 0.875 0.75 0.125
		 0.25 0.125;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ugsdt" no;
	setAttr -s 14 ".vt[0:13]"  -0.5 -0.50000048 0.5 0.5 -0.50000048 0.5
		 -0.5 0.49999952 0.5 0.5 0.49999952 0.5 -0.5 0.49999952 -0.5 0.5 0.49999952 -0.5 -0.5 -0.50000048 -0.5
		 0.5 -0.50000048 -0.5 0 0 3.59867573 0 3.59867573 9.5367432e-07 0 0 -3.5986762 0 -3.5986762 0
		 3.59867477 0 0 -3.59867668 0 9.5367432e-07;
	setAttr -s 36 ".ed[0:35]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0 0 8 1 8 3 1 1 8 1 2 8 1 2 9 1 9 5 1 3 9 1 4 9 1 4 10 1
		 10 7 1 5 10 1 6 10 1 6 11 1 11 1 1 7 11 1 0 11 1 1 12 1 12 5 1 7 12 1 3 12 1 6 13 1
		 13 2 1 0 13 1 4 13 1;
	setAttr -s 24 -ch 72 ".fc[0:23]" -type "polyFaces" 
		f 3 15 13 -2
		mu 0 3 2 14 3
		f 3 19 17 -3
		mu 0 3 4 15 5
		f 3 23 21 -4
		mu 0 3 6 16 7
		f 3 27 25 -1
		mu 0 3 8 17 9
		f 3 31 29 -8
		mu 0 3 3 18 11
		f 3 35 33 6
		mu 0 3 13 19 2
		f 3 0 14 -13
		mu 0 3 0 1 14
		f 3 -15 5 -14
		mu 0 3 14 1 3
		f 3 12 -16 -5
		mu 0 3 0 14 2
		f 3 1 18 -17
		mu 0 3 2 3 15
		f 3 -19 7 -18
		mu 0 3 15 3 5
		f 3 16 -20 -7
		mu 0 3 2 15 4
		f 3 2 22 -21
		mu 0 3 4 5 16
		f 3 -23 9 -22
		mu 0 3 16 5 7
		f 3 20 -24 -9
		mu 0 3 4 16 6
		f 3 3 26 -25
		mu 0 3 6 7 17
		f 3 -27 11 -26
		mu 0 3 17 7 9
		f 3 24 -28 -11
		mu 0 3 6 17 8
		f 3 -12 30 -29
		mu 0 3 1 10 18
		f 3 -31 -10 -30
		mu 0 3 18 10 11
		f 3 28 -32 -6
		mu 0 3 1 18 3
		f 3 10 34 -33
		mu 0 3 12 0 19
		f 3 -35 4 -34
		mu 0 3 19 0 2
		f 3 32 -36 8
		mu 0 3 12 19 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".dr" 1;
createNode transform -n "pCube4";
	rename -uid "E0CA48AE-48BD-1260-C084-AD98ABFF68A2";
createNode mesh -n "pCubeShape4" -p "pCube4";
	rename -uid "CEEAC1B4-4410-CBFA-11E8-87876CFDA8EA";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ugsdt" no;
	setAttr ".dr" 1;
createNode mesh -n "polySurfaceShape3" -p "pCube4";
	rename -uid "642A01B7-485C-D1B3-82FB-EFBB047C53B9";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 20 ".uvst[0].uvsp[0:19]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25 0.5 0.125 0.5 0.375 0.5 0.625 0.5 0.875 0.75 0.125
		 0.25 0.125;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ugsdt" no;
	setAttr -s 14 ".vt[0:13]"  -0.5 -0.50000048 0.5 0.5 -0.50000048 0.5
		 -0.5 0.49999952 0.5 0.5 0.49999952 0.5 -0.5 0.49999952 -0.5 0.5 0.49999952 -0.5 -0.5 -0.50000048 -0.5
		 0.5 -0.50000048 -0.5 0 0 3.59867573 0 3.59867573 9.5367432e-07 0 0 -3.5986762 0 -3.5986762 0
		 3.59867477 0 0 -3.59867668 0 9.5367432e-07;
	setAttr -s 36 ".ed[0:35]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0 0 8 1 8 3 1 1 8 1 2 8 1 2 9 1 9 5 1 3 9 1 4 9 1 4 10 1
		 10 7 1 5 10 1 6 10 1 6 11 1 11 1 1 7 11 1 0 11 1 1 12 1 12 5 1 7 12 1 3 12 1 6 13 1
		 13 2 1 0 13 1 4 13 1;
	setAttr -s 24 -ch 72 ".fc[0:23]" -type "polyFaces" 
		f 3 15 13 -2
		mu 0 3 2 14 3
		f 3 19 17 -3
		mu 0 3 4 15 5
		f 3 23 21 -4
		mu 0 3 6 16 7
		f 3 27 25 -1
		mu 0 3 8 17 9
		f 3 31 29 -8
		mu 0 3 3 18 11
		f 3 35 33 6
		mu 0 3 13 19 2
		f 3 0 14 -13
		mu 0 3 0 1 14
		f 3 -15 5 -14
		mu 0 3 14 1 3
		f 3 12 -16 -5
		mu 0 3 0 14 2
		f 3 1 18 -17
		mu 0 3 2 3 15
		f 3 -19 7 -18
		mu 0 3 15 3 5
		f 3 16 -20 -7
		mu 0 3 2 15 4
		f 3 2 22 -21
		mu 0 3 4 5 16
		f 3 -23 9 -22
		mu 0 3 16 5 7
		f 3 20 -24 -9
		mu 0 3 4 16 6
		f 3 3 26 -25
		mu 0 3 6 7 17
		f 3 -27 11 -26
		mu 0 3 17 7 9
		f 3 24 -28 -11
		mu 0 3 6 17 8
		f 3 -12 30 -29
		mu 0 3 1 10 18
		f 3 -31 -10 -30
		mu 0 3 18 10 11
		f 3 28 -32 -6
		mu 0 3 1 18 3
		f 3 10 34 -33
		mu 0 3 12 0 19
		f 3 -35 4 -34
		mu 0 3 19 0 2
		f 3 32 -36 8
		mu 0 3 12 19 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".dr" 1;
createNode transform -n "pCube5";
	rename -uid "A3886BF4-4850-07AF-825D-0F8D4932F366";
createNode mesh -n "pCubeShape5" -p "pCube5";
	rename -uid "3FDD13DA-4E31-D827-4584-B8BDEB8D0485";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ugsdt" no;
	setAttr ".dr" 1;
createNode mesh -n "polySurfaceShape4" -p "pCube5";
	rename -uid "C9D9FAD8-4890-0271-97CC-B6907CCD147C";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 20 ".uvst[0].uvsp[0:19]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25 0.5 0.125 0.5 0.375 0.5 0.625 0.5 0.875 0.75 0.125
		 0.25 0.125;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ugsdt" no;
	setAttr -s 14 ".vt[0:13]"  -0.5 -0.50000048 0.5 0.5 -0.50000048 0.5
		 -0.5 0.49999952 0.5 0.5 0.49999952 0.5 -0.5 0.49999952 -0.5 0.5 0.49999952 -0.5 -0.5 -0.50000048 -0.5
		 0.5 -0.50000048 -0.5 0 0 3.59867573 0 3.59867573 9.5367432e-07 0 0 -3.5986762 0 -3.5986762 0
		 3.59867477 0 0 -3.59867668 0 9.5367432e-07;
	setAttr -s 36 ".ed[0:35]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0 0 8 1 8 3 1 1 8 1 2 8 1 2 9 1 9 5 1 3 9 1 4 9 1 4 10 1
		 10 7 1 5 10 1 6 10 1 6 11 1 11 1 1 7 11 1 0 11 1 1 12 1 12 5 1 7 12 1 3 12 1 6 13 1
		 13 2 1 0 13 1 4 13 1;
	setAttr -s 24 -ch 72 ".fc[0:23]" -type "polyFaces" 
		f 3 15 13 -2
		mu 0 3 2 14 3
		f 3 19 17 -3
		mu 0 3 4 15 5
		f 3 23 21 -4
		mu 0 3 6 16 7
		f 3 27 25 -1
		mu 0 3 8 17 9
		f 3 31 29 -8
		mu 0 3 3 18 11
		f 3 35 33 6
		mu 0 3 13 19 2
		f 3 0 14 -13
		mu 0 3 0 1 14
		f 3 -15 5 -14
		mu 0 3 14 1 3
		f 3 12 -16 -5
		mu 0 3 0 14 2
		f 3 1 18 -17
		mu 0 3 2 3 15
		f 3 -19 7 -18
		mu 0 3 15 3 5
		f 3 16 -20 -7
		mu 0 3 2 15 4
		f 3 2 22 -21
		mu 0 3 4 5 16
		f 3 -23 9 -22
		mu 0 3 16 5 7
		f 3 20 -24 -9
		mu 0 3 4 16 6
		f 3 3 26 -25
		mu 0 3 6 7 17
		f 3 -27 11 -26
		mu 0 3 17 7 9
		f 3 24 -28 -11
		mu 0 3 6 17 8
		f 3 -12 30 -29
		mu 0 3 1 10 18
		f 3 -31 -10 -30
		mu 0 3 18 10 11
		f 3 28 -32 -6
		mu 0 3 1 18 3
		f 3 10 34 -33
		mu 0 3 12 0 19
		f 3 -35 4 -34
		mu 0 3 19 0 2
		f 3 32 -36 8
		mu 0 3 12 19 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".dr" 1;
createNode transform -n "pCube6";
	rename -uid "9B70993E-4A96-5A0B-07DB-AE9EAEDAE0E3";
createNode mesh -n "pCubeShape6" -p "pCube6";
	rename -uid "20CBF79E-4BE3-49F0-1ECF-309E4B15E991";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ugsdt" no;
	setAttr ".dr" 1;
createNode mesh -n "polySurfaceShape5" -p "pCube6";
	rename -uid "F986E478-4997-69B2-6765-0A86F73B7E99";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 20 ".uvst[0].uvsp[0:19]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25 0.5 0.125 0.5 0.375 0.5 0.625 0.5 0.875 0.75 0.125
		 0.25 0.125;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ugsdt" no;
	setAttr -s 14 ".vt[0:13]"  -0.5 -0.50000048 0.5 0.5 -0.50000048 0.5
		 -0.5 0.49999952 0.5 0.5 0.49999952 0.5 -0.5 0.49999952 -0.5 0.5 0.49999952 -0.5 -0.5 -0.50000048 -0.5
		 0.5 -0.50000048 -0.5 0 0 3.59867573 0 3.59867573 9.5367432e-07 0 0 -3.5986762 0 -3.5986762 0
		 3.59867477 0 0 -3.59867668 0 9.5367432e-07;
	setAttr -s 36 ".ed[0:35]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0 0 8 1 8 3 1 1 8 1 2 8 1 2 9 1 9 5 1 3 9 1 4 9 1 4 10 1
		 10 7 1 5 10 1 6 10 1 6 11 1 11 1 1 7 11 1 0 11 1 1 12 1 12 5 1 7 12 1 3 12 1 6 13 1
		 13 2 1 0 13 1 4 13 1;
	setAttr -s 24 -ch 72 ".fc[0:23]" -type "polyFaces" 
		f 3 15 13 -2
		mu 0 3 2 14 3
		f 3 19 17 -3
		mu 0 3 4 15 5
		f 3 23 21 -4
		mu 0 3 6 16 7
		f 3 27 25 -1
		mu 0 3 8 17 9
		f 3 31 29 -8
		mu 0 3 3 18 11
		f 3 35 33 6
		mu 0 3 13 19 2
		f 3 0 14 -13
		mu 0 3 0 1 14
		f 3 -15 5 -14
		mu 0 3 14 1 3
		f 3 12 -16 -5
		mu 0 3 0 14 2
		f 3 1 18 -17
		mu 0 3 2 3 15
		f 3 -19 7 -18
		mu 0 3 15 3 5
		f 3 16 -20 -7
		mu 0 3 2 15 4
		f 3 2 22 -21
		mu 0 3 4 5 16
		f 3 -23 9 -22
		mu 0 3 16 5 7
		f 3 20 -24 -9
		mu 0 3 4 16 6
		f 3 3 26 -25
		mu 0 3 6 7 17
		f 3 -27 11 -26
		mu 0 3 17 7 9
		f 3 24 -28 -11
		mu 0 3 6 17 8
		f 3 -12 30 -29
		mu 0 3 1 10 18
		f 3 -31 -10 -30
		mu 0 3 18 10 11
		f 3 28 -32 -6
		mu 0 3 1 18 3
		f 3 10 34 -33
		mu 0 3 12 0 19
		f 3 -35 4 -34
		mu 0 3 19 0 2
		f 3 32 -36 8
		mu 0 3 12 19 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".dr" 1;
createNode transform -n "pCube7";
	rename -uid "39CC1E40-4E8A-4382-140B-C6AF2B31BE37";
createNode mesh -n "pCubeShape7" -p "pCube7";
	rename -uid "B67815A3-4FF9-EC0C-D811-C795F6762740";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ugsdt" no;
	setAttr ".dr" 1;
createNode mesh -n "polySurfaceShape6" -p "pCube7";
	rename -uid "8BCCD76A-4C71-F245-FC6D-40A44F22639B";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 20 ".uvst[0].uvsp[0:19]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25 0.5 0.125 0.5 0.375 0.5 0.625 0.5 0.875 0.75 0.125
		 0.25 0.125;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ugsdt" no;
	setAttr -s 14 ".vt[0:13]"  -0.5 -0.50000048 0.5 0.5 -0.50000048 0.5
		 -0.5 0.49999952 0.5 0.5 0.49999952 0.5 -0.5 0.49999952 -0.5 0.5 0.49999952 -0.5 -0.5 -0.50000048 -0.5
		 0.5 -0.50000048 -0.5 0 0 3.59867573 0 3.59867573 9.5367432e-07 0 0 -3.5986762 0 -3.5986762 0
		 3.59867477 0 0 -3.59867668 0 9.5367432e-07;
	setAttr -s 36 ".ed[0:35]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0 0 8 1 8 3 1 1 8 1 2 8 1 2 9 1 9 5 1 3 9 1 4 9 1 4 10 1
		 10 7 1 5 10 1 6 10 1 6 11 1 11 1 1 7 11 1 0 11 1 1 12 1 12 5 1 7 12 1 3 12 1 6 13 1
		 13 2 1 0 13 1 4 13 1;
	setAttr -s 24 -ch 72 ".fc[0:23]" -type "polyFaces" 
		f 3 15 13 -2
		mu 0 3 2 14 3
		f 3 19 17 -3
		mu 0 3 4 15 5
		f 3 23 21 -4
		mu 0 3 6 16 7
		f 3 27 25 -1
		mu 0 3 8 17 9
		f 3 31 29 -8
		mu 0 3 3 18 11
		f 3 35 33 6
		mu 0 3 13 19 2
		f 3 0 14 -13
		mu 0 3 0 1 14
		f 3 -15 5 -14
		mu 0 3 14 1 3
		f 3 12 -16 -5
		mu 0 3 0 14 2
		f 3 1 18 -17
		mu 0 3 2 3 15
		f 3 -19 7 -18
		mu 0 3 15 3 5
		f 3 16 -20 -7
		mu 0 3 2 15 4
		f 3 2 22 -21
		mu 0 3 4 5 16
		f 3 -23 9 -22
		mu 0 3 16 5 7
		f 3 20 -24 -9
		mu 0 3 4 16 6
		f 3 3 26 -25
		mu 0 3 6 7 17
		f 3 -27 11 -26
		mu 0 3 17 7 9
		f 3 24 -28 -11
		mu 0 3 6 17 8
		f 3 -12 30 -29
		mu 0 3 1 10 18
		f 3 -31 -10 -30
		mu 0 3 18 10 11
		f 3 28 -32 -6
		mu 0 3 1 18 3
		f 3 10 34 -33
		mu 0 3 12 0 19
		f 3 -35 4 -34
		mu 0 3 19 0 2
		f 3 32 -36 8
		mu 0 3 12 19 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".dr" 1;
createNode transform -n "pCube8";
	rename -uid "E7FBD52E-444A-2CE5-29CB-D79C96ABEC5C";
createNode mesh -n "pCubeShape8" -p "pCube8";
	rename -uid "9C4732ED-4BBA-A559-9189-A58587A2F216";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ugsdt" no;
	setAttr ".dr" 1;
createNode mesh -n "polySurfaceShape7" -p "pCube8";
	rename -uid "33D99475-4480-7608-2738-05A298EC5069";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 20 ".uvst[0].uvsp[0:19]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25 0.5 0.125 0.5 0.375 0.5 0.625 0.5 0.875 0.75 0.125
		 0.25 0.125;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ugsdt" no;
	setAttr -s 14 ".vt[0:13]"  -0.5 -0.50000048 0.5 0.5 -0.50000048 0.5
		 -0.5 0.49999952 0.5 0.5 0.49999952 0.5 -0.5 0.49999952 -0.5 0.5 0.49999952 -0.5 -0.5 -0.50000048 -0.5
		 0.5 -0.50000048 -0.5 0 0 3.59867573 0 3.59867573 9.5367432e-07 0 0 -3.5986762 0 -3.5986762 0
		 3.59867477 0 0 -3.59867668 0 9.5367432e-07;
	setAttr -s 36 ".ed[0:35]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0 0 8 1 8 3 1 1 8 1 2 8 1 2 9 1 9 5 1 3 9 1 4 9 1 4 10 1
		 10 7 1 5 10 1 6 10 1 6 11 1 11 1 1 7 11 1 0 11 1 1 12 1 12 5 1 7 12 1 3 12 1 6 13 1
		 13 2 1 0 13 1 4 13 1;
	setAttr -s 24 -ch 72 ".fc[0:23]" -type "polyFaces" 
		f 3 15 13 -2
		mu 0 3 2 14 3
		f 3 19 17 -3
		mu 0 3 4 15 5
		f 3 23 21 -4
		mu 0 3 6 16 7
		f 3 27 25 -1
		mu 0 3 8 17 9
		f 3 31 29 -8
		mu 0 3 3 18 11
		f 3 35 33 6
		mu 0 3 13 19 2
		f 3 0 14 -13
		mu 0 3 0 1 14
		f 3 -15 5 -14
		mu 0 3 14 1 3
		f 3 12 -16 -5
		mu 0 3 0 14 2
		f 3 1 18 -17
		mu 0 3 2 3 15
		f 3 -19 7 -18
		mu 0 3 15 3 5
		f 3 16 -20 -7
		mu 0 3 2 15 4
		f 3 2 22 -21
		mu 0 3 4 5 16
		f 3 -23 9 -22
		mu 0 3 16 5 7
		f 3 20 -24 -9
		mu 0 3 4 16 6
		f 3 3 26 -25
		mu 0 3 6 7 17
		f 3 -27 11 -26
		mu 0 3 17 7 9
		f 3 24 -28 -11
		mu 0 3 6 17 8
		f 3 -12 30 -29
		mu 0 3 1 10 18
		f 3 -31 -10 -30
		mu 0 3 18 10 11
		f 3 28 -32 -6
		mu 0 3 1 18 3
		f 3 10 34 -33
		mu 0 3 12 0 19
		f 3 -35 4 -34
		mu 0 3 19 0 2
		f 3 32 -36 8
		mu 0 3 12 19 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".dr" 1;
createNode transform -n "pCube9";
	rename -uid "5F7A8ADF-4AA5-9800-AA3B-A9ADF97B88C4";
createNode mesh -n "pCubeShape9" -p "pCube9";
	rename -uid "41F9E229-4A99-0CBD-4BE4-92B200CAC07F";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ugsdt" no;
	setAttr ".dr" 1;
createNode mesh -n "polySurfaceShape8" -p "pCube9";
	rename -uid "B45115FF-4D2A-71B4-3EF4-60B3A15901EB";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 20 ".uvst[0].uvsp[0:19]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25 0.5 0.125 0.5 0.375 0.5 0.625 0.5 0.875 0.75 0.125
		 0.25 0.125;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ugsdt" no;
	setAttr -s 14 ".vt[0:13]"  -0.5 -0.50000048 0.5 0.5 -0.50000048 0.5
		 -0.5 0.49999952 0.5 0.5 0.49999952 0.5 -0.5 0.49999952 -0.5 0.5 0.49999952 -0.5 -0.5 -0.50000048 -0.5
		 0.5 -0.50000048 -0.5 0 0 3.59867573 0 3.59867573 9.5367432e-07 0 0 -3.5986762 0 -3.5986762 0
		 3.59867477 0 0 -3.59867668 0 9.5367432e-07;
	setAttr -s 36 ".ed[0:35]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0 0 8 1 8 3 1 1 8 1 2 8 1 2 9 1 9 5 1 3 9 1 4 9 1 4 10 1
		 10 7 1 5 10 1 6 10 1 6 11 1 11 1 1 7 11 1 0 11 1 1 12 1 12 5 1 7 12 1 3 12 1 6 13 1
		 13 2 1 0 13 1 4 13 1;
	setAttr -s 24 -ch 72 ".fc[0:23]" -type "polyFaces" 
		f 3 15 13 -2
		mu 0 3 2 14 3
		f 3 19 17 -3
		mu 0 3 4 15 5
		f 3 23 21 -4
		mu 0 3 6 16 7
		f 3 27 25 -1
		mu 0 3 8 17 9
		f 3 31 29 -8
		mu 0 3 3 18 11
		f 3 35 33 6
		mu 0 3 13 19 2
		f 3 0 14 -13
		mu 0 3 0 1 14
		f 3 -15 5 -14
		mu 0 3 14 1 3
		f 3 12 -16 -5
		mu 0 3 0 14 2
		f 3 1 18 -17
		mu 0 3 2 3 15
		f 3 -19 7 -18
		mu 0 3 15 3 5
		f 3 16 -20 -7
		mu 0 3 2 15 4
		f 3 2 22 -21
		mu 0 3 4 5 16
		f 3 -23 9 -22
		mu 0 3 16 5 7
		f 3 20 -24 -9
		mu 0 3 4 16 6
		f 3 3 26 -25
		mu 0 3 6 7 17
		f 3 -27 11 -26
		mu 0 3 17 7 9
		f 3 24 -28 -11
		mu 0 3 6 17 8
		f 3 -12 30 -29
		mu 0 3 1 10 18
		f 3 -31 -10 -30
		mu 0 3 18 10 11
		f 3 28 -32 -6
		mu 0 3 1 18 3
		f 3 10 34 -33
		mu 0 3 12 0 19
		f 3 -35 4 -34
		mu 0 3 19 0 2
		f 3 32 -36 8
		mu 0 3 12 19 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".dr" 1;
createNode transform -n "pCube10";
	rename -uid "FF817CAA-4F48-EE62-02F1-6C8A4851BD6A";
createNode mesh -n "pCubeShape10" -p "pCube10";
	rename -uid "135117EF-46C0-C2AE-5DF6-C19D8570D84E";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ugsdt" no;
	setAttr ".dr" 1;
createNode mesh -n "polySurfaceShape9" -p "pCube10";
	rename -uid "1BC999E6-4E8F-B170-9299-D597D4EC2A22";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 20 ".uvst[0].uvsp[0:19]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25 0.5 0.125 0.5 0.375 0.5 0.625 0.5 0.875 0.75 0.125
		 0.25 0.125;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ugsdt" no;
	setAttr -s 14 ".vt[0:13]"  -0.5 -0.50000048 0.5 0.5 -0.50000048 0.5
		 -0.5 0.49999952 0.5 0.5 0.49999952 0.5 -0.5 0.49999952 -0.5 0.5 0.49999952 -0.5 -0.5 -0.50000048 -0.5
		 0.5 -0.50000048 -0.5 0 0 3.59867573 0 3.59867573 9.5367432e-07 0 0 -3.5986762 0 -3.5986762 0
		 3.59867477 0 0 -3.59867668 0 9.5367432e-07;
	setAttr -s 36 ".ed[0:35]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0 0 8 1 8 3 1 1 8 1 2 8 1 2 9 1 9 5 1 3 9 1 4 9 1 4 10 1
		 10 7 1 5 10 1 6 10 1 6 11 1 11 1 1 7 11 1 0 11 1 1 12 1 12 5 1 7 12 1 3 12 1 6 13 1
		 13 2 1 0 13 1 4 13 1;
	setAttr -s 24 -ch 72 ".fc[0:23]" -type "polyFaces" 
		f 3 15 13 -2
		mu 0 3 2 14 3
		f 3 19 17 -3
		mu 0 3 4 15 5
		f 3 23 21 -4
		mu 0 3 6 16 7
		f 3 27 25 -1
		mu 0 3 8 17 9
		f 3 31 29 -8
		mu 0 3 3 18 11
		f 3 35 33 6
		mu 0 3 13 19 2
		f 3 0 14 -13
		mu 0 3 0 1 14
		f 3 -15 5 -14
		mu 0 3 14 1 3
		f 3 12 -16 -5
		mu 0 3 0 14 2
		f 3 1 18 -17
		mu 0 3 2 3 15
		f 3 -19 7 -18
		mu 0 3 15 3 5
		f 3 16 -20 -7
		mu 0 3 2 15 4
		f 3 2 22 -21
		mu 0 3 4 5 16
		f 3 -23 9 -22
		mu 0 3 16 5 7
		f 3 20 -24 -9
		mu 0 3 4 16 6
		f 3 3 26 -25
		mu 0 3 6 7 17
		f 3 -27 11 -26
		mu 0 3 17 7 9
		f 3 24 -28 -11
		mu 0 3 6 17 8
		f 3 -12 30 -29
		mu 0 3 1 10 18
		f 3 -31 -10 -30
		mu 0 3 18 10 11
		f 3 28 -32 -6
		mu 0 3 1 18 3
		f 3 10 34 -33
		mu 0 3 12 0 19
		f 3 -35 4 -34
		mu 0 3 19 0 2
		f 3 32 -36 8
		mu 0 3 12 19 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".dr" 1;
createNode transform -n "pCube11";
	rename -uid "53B74FB1-432A-F5C8-78D4-25B049699F23";
createNode mesh -n "pCubeShape11" -p "pCube11";
	rename -uid "A50F6D6A-41D7-D001-CA68-50B28B043516";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ugsdt" no;
	setAttr -s 102 ".pt";
	setAttr ".pt[8]" -type "float3" -6.2527761e-13 1.9895197e-13 2.6226044e-06 ;
	setAttr ".pt[9]" -type "float3" -6.2527761e-13 2.6226044e-06 -5.6843419e-13 ;
	setAttr ".pt[10]" -type "float3" -6.2527761e-13 1.9895197e-13 -2.6226044e-06 ;
	setAttr ".pt[11]" -type "float3" -6.2527761e-13 -2.6226044e-06 -9.9475983e-14 ;
	setAttr ".pt[12]" -type "float3" 2.6226044e-06 1.9895197e-13 -9.9475983e-14 ;
	setAttr ".pt[13]" -type "float3" -2.8610229e-06 1.9895197e-13 0 ;
	setAttr ".pt[26]" -type "float3" -5.9604645e-08 -1.1026859e-06 3.0994415e-06 ;
	setAttr ".pt[27]" -type "float3" -1.1920929e-07 9.5367432e-07 3.0994415e-06 ;
	setAttr ".pt[28]" -type "float3" -1.1920929e-07 -1.1026859e-06 3.0994415e-06 ;
	setAttr ".pt[29]" -type "float3" -5.9604645e-08 9.5367432e-07 3.0994415e-06 ;
	setAttr ".pt[30]" -type "float3" -5.9604645e-08 3.3378601e-06 5.9604645e-08 ;
	setAttr ".pt[31]" -type "float3" -1.1920929e-07 3.3378601e-06 0 ;
	setAttr ".pt[32]" -type "float3" -1.1920929e-07 3.3378601e-06 5.9604645e-08 ;
	setAttr ".pt[33]" -type "float3" -5.9604645e-08 3.3378601e-06 0 ;
	setAttr ".pt[34]" -type "float3" -5.9604645e-08 9.5367432e-07 -3.3378601e-06 ;
	setAttr ".pt[35]" -type "float3" -1.1920929e-07 -1.1026859e-06 -3.3378601e-06 ;
	setAttr ".pt[36]" -type "float3" -1.1920929e-07 9.5367432e-07 -3.3378601e-06 ;
	setAttr ".pt[37]" -type "float3" -5.9604645e-08 -1.1026859e-06 -3.3378601e-06 ;
	setAttr ".pt[38]" -type "float3" -5.9604645e-08 -3.5762787e-06 -1.0430813e-06 ;
	setAttr ".pt[39]" -type "float3" -1.1920929e-07 -3.5762787e-06 7.4505806e-07 ;
	setAttr ".pt[40]" -type "float3" -1.1920929e-07 -3.5762787e-06 -1.0430813e-06 ;
	setAttr ".pt[41]" -type "float3" -5.9604645e-08 -3.5762787e-06 7.4505806e-07 ;
	setAttr ".pt[42]" -type "float3" 2.8610229e-06 -1.1026859e-06 7.4505806e-07 ;
	setAttr ".pt[43]" -type "float3" 2.8610229e-06 9.5367432e-07 -1.0430813e-06 ;
	setAttr ".pt[44]" -type "float3" 2.8610229e-06 -1.1026859e-06 -1.0430813e-06 ;
	setAttr ".pt[45]" -type "float3" 2.8610229e-06 9.5367432e-07 7.4505806e-07 ;
	setAttr ".pt[46]" -type "float3" -4.2915344e-06 -1.1026859e-06 0 ;
	setAttr ".pt[47]" -type "float3" -4.2915344e-06 9.5367432e-07 5.9604645e-08 ;
	setAttr ".pt[48]" -type "float3" -4.2915344e-06 -1.1026859e-06 5.9604645e-08 ;
	setAttr ".pt[49]" -type "float3" -4.2915344e-06 9.5367432e-07 0 ;
	setAttr ".pt[50]" -type "float3" -6.2527761e-13 -5.9604645e-07 -1.1920929e-06 ;
	setAttr ".pt[51]" -type "float3" -6.2527761e-13 -9.5367432e-07 2.3841858e-07 ;
	setAttr ".pt[52]" -type "float3" -6.2527761e-13 5.364418e-07 9.5367432e-07 ;
	setAttr ".pt[53]" -type "float3" -6.2527761e-13 1.1920929e-06 -8.3446503e-07 ;
	setAttr ".pt[54]" -type "float3" -9.5367432e-07 -5.9604645e-07 -9.9475983e-14 ;
	setAttr ".pt[55]" -type "float3" -1.4305115e-06 -5.9604645e-07 7.3896445e-13 ;
	setAttr ".pt[56]" -type "float3" -6.2527761e-13 5.364418e-07 -1.1920929e-06 ;
	setAttr ".pt[57]" -type "float3" -2.682209e-07 -1.7763568e-14 -1.1920929e-06 ;
	setAttr ".pt[58]" -type "float3" -1.4901161e-07 -1.7763568e-14 -1.1920929e-06 ;
	setAttr ".pt[59]" -type "float3" -6.2527761e-13 -9.5367432e-07 -4.1723251e-07 ;
	setAttr ".pt[60]" -type "float3" -2.682209e-07 -9.5367432e-07 7.3896445e-13 ;
	setAttr ".pt[61]" -type "float3" -1.4901161e-07 -9.5367432e-07 7.3896445e-13 ;
	setAttr ".pt[62]" -type "float3" -6.2527761e-13 -5.9604645e-07 9.5367432e-07 ;
	setAttr ".pt[63]" -type "float3" -2.682209e-07 -1.7763568e-14 9.5367432e-07 ;
	setAttr ".pt[64]" -type "float3" -1.4901161e-07 -1.7763568e-14 9.5367432e-07 ;
	setAttr ".pt[65]" -type "float3" -6.2527761e-13 1.1920929e-06 2.682209e-07 ;
	setAttr ".pt[66]" -type "float3" -2.682209e-07 1.1920929e-06 -9.9475983e-14 ;
	setAttr ".pt[67]" -type "float3" -1.4901161e-07 1.1920929e-06 -9.9475983e-14 ;
	setAttr ".pt[68]" -type "float3" -1.4901161e-06 2.3841858e-07 -2.3841858e-06 ;
	setAttr ".pt[69]" -type "float3" -9.5367432e-07 -1.7763565e-14 9.5367432e-07 ;
	setAttr ".pt[70]" -type "float3" -9.5367432e-07 0 -1.4305115e-06 ;
	setAttr ".pt[71]" -type "float3" -1.4305085e-06 -5.9604645e-07 -5.2452087e-06 ;
	setAttr ".pt[72]" -type "float3" -1.6093254e-06 -2.9802322e-07 -1.9073486e-06 ;
	setAttr ".pt[73]" -type "float3" -1.4901161e-06 -2.9802322e-07 -2.8610229e-06 ;
	setAttr ".pt[74]" -type "float3" 0 -8.3446503e-07 -5.2452087e-06 ;
	setAttr ".pt[75]" -type "float3" 8.3446503e-07 0 -5.2452087e-06 ;
	setAttr ".pt[76]" -type "float3" -8.3446503e-07 0 -5.2452087e-06 ;
	setAttr ".pt[77]" -type "float3" 1.7881393e-07 -1.4305115e-06 1.1920929e-07 ;
	setAttr ".pt[78]" -type "float3" 0 9.5367432e-07 -9.094947e-13 ;
	setAttr ".pt[79]" -type "float3" -1.7881393e-07 -1.4305115e-06 1.1920929e-07 ;
	setAttr ".pt[80]" -type "float3" 0 -4.7683716e-06 -9.5367432e-07 ;
	setAttr ".pt[81]" -type "float3" -1.7881393e-07 -1.4305115e-06 0 ;
	setAttr ".pt[82]" -type "float3" 1.7881393e-07 -1.4305115e-06 0 ;
	setAttr ".pt[83]" -type "float3" 0 -4.7683716e-06 2.3841858e-07 ;
	setAttr ".pt[84]" -type "float3" 8.3446503e-07 -4.7683716e-06 -4.5474735e-13 ;
	setAttr ".pt[85]" -type "float3" -8.3446503e-07 -4.7683716e-06 -4.5474735e-13 ;
	setAttr ".pt[86]" -type "float3" 1.7881393e-07 -2.9802322e-07 1.9073486e-06 ;
	setAttr ".pt[87]" -type "float3" 0 0 -9.5367432e-07 ;
	setAttr ".pt[88]" -type "float3" -1.7881393e-07 -2.9802322e-07 1.9073486e-06 ;
	setAttr ".pt[89]" -type "float3" 0 -8.3446503e-07 5.2452087e-06 ;
	setAttr ".pt[90]" -type "float3" -1.7881393e-07 0 1.9073486e-06 ;
	setAttr ".pt[91]" -type "float3" 1.7881393e-07 0 1.9073486e-06 ;
	setAttr ".pt[92]" -type "float3" 0 -1.1920929e-07 5.2452087e-06 ;
	setAttr ".pt[93]" -type "float3" 8.3446503e-07 0 5.2452087e-06 ;
	setAttr ".pt[94]" -type "float3" -8.3446503e-07 0 5.2452087e-06 ;
	setAttr ".pt[95]" -type "float3" 1.7881393e-07 1.4305115e-06 -1.7881393e-07 ;
	setAttr ".pt[96]" -type "float3" 0 -9.5367432e-07 0 ;
	setAttr ".pt[97]" -type "float3" -1.7881393e-07 1.4305115e-06 -1.7881393e-07 ;
	setAttr ".pt[98]" -type "float3" 0 5.2452087e-06 1.1920929e-06 ;
	setAttr ".pt[99]" -type "float3" -1.7881393e-07 1.4305115e-06 -5.9604645e-08 ;
	setAttr ".pt[100]" -type "float3" 1.7881393e-07 1.4305115e-06 -5.9604645e-08 ;
	setAttr ".pt[101]" -type "float3" 0 5.2452087e-06 -7.1525574e-07 ;
	setAttr ".pt[102]" -type "float3" 8.3446503e-07 5.2452087e-06 0 ;
	setAttr ".pt[103]" -type "float3" -8.3446503e-07 5.2452087e-06 0 ;
	setAttr ".pt[104]" -type "float3" -3.3378601e-06 0 -1.7881393e-07 ;
	setAttr ".pt[105]" -type "float3" 9.5367432e-07 0 0 ;
	setAttr ".pt[106]" -type "float3" -3.3378601e-06 0 -5.9604645e-08 ;
	setAttr ".pt[107]" -type "float3" -5.2452087e-06 -1.1920929e-07 0 ;
	setAttr ".pt[108]" -type "float3" -3.3378601e-06 -2.9802322e-07 -5.9604645e-08 ;
	setAttr ".pt[109]" -type "float3" -3.3378601e-06 -2.9802322e-07 -1.7881393e-07 ;
	setAttr ".pt[110]" -type "float3" -5.2452087e-06 -8.3446503e-07 0 ;
	setAttr ".pt[111]" -type "float3" -5.2452087e-06 0 -7.1525574e-07 ;
	setAttr ".pt[112]" -type "float3" -5.2452087e-06 0 1.1920929e-06 ;
	setAttr ".pt[113]" -type "float3" 3.3378601e-06 0 1.1920929e-07 ;
	setAttr ".pt[114]" -type "float3" -9.5367432e-07 0 -9.094947e-13 ;
	setAttr ".pt[115]" -type "float3" 3.3378601e-06 0 0 ;
	setAttr ".pt[116]" -type "float3" 4.2915344e-06 -1.1920929e-07 -4.5474735e-13 ;
	setAttr ".pt[117]" -type "float3" 3.3378601e-06 -2.9802322e-07 0 ;
	setAttr ".pt[118]" -type "float3" 3.3378601e-06 -2.9802322e-07 1.1920929e-07 ;
	setAttr ".pt[119]" -type "float3" 4.2915344e-06 -8.3446503e-07 -4.5474735e-13 ;
	setAttr ".pt[120]" -type "float3" 4.2915344e-06 0 2.3841858e-07 ;
	setAttr ".pt[121]" -type "float3" 4.2915344e-06 0 -9.5367432e-07 ;
	setAttr ".dr" 1;
createNode mesh -n "polySurfaceShape10" -p "pCube11";
	rename -uid "9AC4E075-4520-529A-FAA7-B5A23FF7B582";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 20 ".uvst[0].uvsp[0:19]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25 0.5 0.125 0.5 0.375 0.5 0.625 0.5 0.875 0.75 0.125
		 0.25 0.125;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ugsdt" no;
	setAttr -s 14 ".vt[0:13]"  -0.5 -0.50000048 0.5 0.5 -0.50000048 0.5
		 -0.5 0.49999952 0.5 0.5 0.49999952 0.5 -0.5 0.49999952 -0.5 0.5 0.49999952 -0.5 -0.5 -0.50000048 -0.5
		 0.5 -0.50000048 -0.5 0 0 3.59867573 0 3.59867573 9.5367432e-07 0 0 -3.5986762 0 -3.5986762 0
		 3.59867477 0 0 -3.59867668 0 9.5367432e-07;
	setAttr -s 36 ".ed[0:35]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0 0 8 1 8 3 1 1 8 1 2 8 1 2 9 1 9 5 1 3 9 1 4 9 1 4 10 1
		 10 7 1 5 10 1 6 10 1 6 11 1 11 1 1 7 11 1 0 11 1 1 12 1 12 5 1 7 12 1 3 12 1 6 13 1
		 13 2 1 0 13 1 4 13 1;
	setAttr -s 24 -ch 72 ".fc[0:23]" -type "polyFaces" 
		f 3 15 13 -2
		mu 0 3 2 14 3
		f 3 19 17 -3
		mu 0 3 4 15 5
		f 3 23 21 -4
		mu 0 3 6 16 7
		f 3 27 25 -1
		mu 0 3 8 17 9
		f 3 31 29 -8
		mu 0 3 3 18 11
		f 3 35 33 6
		mu 0 3 13 19 2
		f 3 0 14 -13
		mu 0 3 0 1 14
		f 3 -15 5 -14
		mu 0 3 14 1 3
		f 3 12 -16 -5
		mu 0 3 0 14 2
		f 3 1 18 -17
		mu 0 3 2 3 15
		f 3 -19 7 -18
		mu 0 3 15 3 5
		f 3 16 -20 -7
		mu 0 3 2 15 4
		f 3 2 22 -21
		mu 0 3 4 5 16
		f 3 -23 9 -22
		mu 0 3 16 5 7
		f 3 20 -24 -9
		mu 0 3 4 16 6
		f 3 3 26 -25
		mu 0 3 6 7 17
		f 3 -27 11 -26
		mu 0 3 17 7 9
		f 3 24 -28 -11
		mu 0 3 6 17 8
		f 3 -12 30 -29
		mu 0 3 1 10 18
		f 3 -31 -10 -30
		mu 0 3 18 10 11
		f 3 28 -32 -6
		mu 0 3 1 18 3
		f 3 10 34 -33
		mu 0 3 12 0 19
		f 3 -35 4 -34
		mu 0 3 19 0 2
		f 3 32 -36 8
		mu 0 3 12 19 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".dr" 1;
createNode transform -n "pCube12";
	rename -uid "B0A59097-401A-C223-D229-6992A9F3D512";
createNode mesh -n "pCubeShape12" -p "pCube12";
	rename -uid "79226698-47C0-F703-37EC-52BF8FA37618";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ugsdt" no;
	setAttr ".dr" 1;
createNode mesh -n "polySurfaceShape11" -p "pCube12";
	rename -uid "C0D1F6AA-44A5-32B4-4D23-5FB75B0349A2";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 20 ".uvst[0].uvsp[0:19]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25 0.5 0.125 0.5 0.375 0.5 0.625 0.5 0.875 0.75 0.125
		 0.25 0.125;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ugsdt" no;
	setAttr -s 14 ".vt[0:13]"  -0.5 -0.50000048 0.5 0.5 -0.50000048 0.5
		 -0.5 0.49999952 0.5 0.5 0.49999952 0.5 -0.5 0.49999952 -0.5 0.5 0.49999952 -0.5 -0.5 -0.50000048 -0.5
		 0.5 -0.50000048 -0.5 0 0 3.59867573 0 3.59867573 9.5367432e-07 0 0 -3.5986762 0 -3.5986762 0
		 3.59867477 0 0 -3.59867668 0 9.5367432e-07;
	setAttr -s 36 ".ed[0:35]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0 0 8 1 8 3 1 1 8 1 2 8 1 2 9 1 9 5 1 3 9 1 4 9 1 4 10 1
		 10 7 1 5 10 1 6 10 1 6 11 1 11 1 1 7 11 1 0 11 1 1 12 1 12 5 1 7 12 1 3 12 1 6 13 1
		 13 2 1 0 13 1 4 13 1;
	setAttr -s 24 -ch 72 ".fc[0:23]" -type "polyFaces" 
		f 3 15 13 -2
		mu 0 3 2 14 3
		f 3 19 17 -3
		mu 0 3 4 15 5
		f 3 23 21 -4
		mu 0 3 6 16 7
		f 3 27 25 -1
		mu 0 3 8 17 9
		f 3 31 29 -8
		mu 0 3 3 18 11
		f 3 35 33 6
		mu 0 3 13 19 2
		f 3 0 14 -13
		mu 0 3 0 1 14
		f 3 -15 5 -14
		mu 0 3 14 1 3
		f 3 12 -16 -5
		mu 0 3 0 14 2
		f 3 1 18 -17
		mu 0 3 2 3 15
		f 3 -19 7 -18
		mu 0 3 15 3 5
		f 3 16 -20 -7
		mu 0 3 2 15 4
		f 3 2 22 -21
		mu 0 3 4 5 16
		f 3 -23 9 -22
		mu 0 3 16 5 7
		f 3 20 -24 -9
		mu 0 3 4 16 6
		f 3 3 26 -25
		mu 0 3 6 7 17
		f 3 -27 11 -26
		mu 0 3 17 7 9
		f 3 24 -28 -11
		mu 0 3 6 17 8
		f 3 -12 30 -29
		mu 0 3 1 10 18
		f 3 -31 -10 -30
		mu 0 3 18 10 11
		f 3 28 -32 -6
		mu 0 3 1 18 3
		f 3 10 34 -33
		mu 0 3 12 0 19
		f 3 -35 4 -34
		mu 0 3 19 0 2
		f 3 32 -36 8
		mu 0 3 12 19 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".dr" 1;
createNode transform -n "pCube13";
	rename -uid "D0E393A6-4D10-634B-E895-059E9A6D2702";
createNode mesh -n "pCubeShape13" -p "pCube13";
	rename -uid "23CB2C3A-4FB4-CDEF-E607-0396FE015D82";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ugsdt" no;
	setAttr ".dr" 1;
createNode mesh -n "polySurfaceShape12" -p "pCube13";
	rename -uid "996A2859-466F-D131-F942-CEA10846F328";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 20 ".uvst[0].uvsp[0:19]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25 0.5 0.125 0.5 0.375 0.5 0.625 0.5 0.875 0.75 0.125
		 0.25 0.125;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ugsdt" no;
	setAttr -s 14 ".vt[0:13]"  -0.5 -0.50000048 0.5 0.5 -0.50000048 0.5
		 -0.5 0.49999952 0.5 0.5 0.49999952 0.5 -0.5 0.49999952 -0.5 0.5 0.49999952 -0.5 -0.5 -0.50000048 -0.5
		 0.5 -0.50000048 -0.5 0 0 3.59867573 0 3.59867573 9.5367432e-07 0 0 -3.5986762 0 -3.5986762 0
		 3.59867477 0 0 -3.59867668 0 9.5367432e-07;
	setAttr -s 36 ".ed[0:35]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0 0 8 1 8 3 1 1 8 1 2 8 1 2 9 1 9 5 1 3 9 1 4 9 1 4 10 1
		 10 7 1 5 10 1 6 10 1 6 11 1 11 1 1 7 11 1 0 11 1 1 12 1 12 5 1 7 12 1 3 12 1 6 13 1
		 13 2 1 0 13 1 4 13 1;
	setAttr -s 24 -ch 72 ".fc[0:23]" -type "polyFaces" 
		f 3 15 13 -2
		mu 0 3 2 14 3
		f 3 19 17 -3
		mu 0 3 4 15 5
		f 3 23 21 -4
		mu 0 3 6 16 7
		f 3 27 25 -1
		mu 0 3 8 17 9
		f 3 31 29 -8
		mu 0 3 3 18 11
		f 3 35 33 6
		mu 0 3 13 19 2
		f 3 0 14 -13
		mu 0 3 0 1 14
		f 3 -15 5 -14
		mu 0 3 14 1 3
		f 3 12 -16 -5
		mu 0 3 0 14 2
		f 3 1 18 -17
		mu 0 3 2 3 15
		f 3 -19 7 -18
		mu 0 3 15 3 5
		f 3 16 -20 -7
		mu 0 3 2 15 4
		f 3 2 22 -21
		mu 0 3 4 5 16
		f 3 -23 9 -22
		mu 0 3 16 5 7
		f 3 20 -24 -9
		mu 0 3 4 16 6
		f 3 3 26 -25
		mu 0 3 6 7 17
		f 3 -27 11 -26
		mu 0 3 17 7 9
		f 3 24 -28 -11
		mu 0 3 6 17 8
		f 3 -12 30 -29
		mu 0 3 1 10 18
		f 3 -31 -10 -30
		mu 0 3 18 10 11
		f 3 28 -32 -6
		mu 0 3 1 18 3
		f 3 10 34 -33
		mu 0 3 12 0 19
		f 3 -35 4 -34
		mu 0 3 19 0 2
		f 3 32 -36 8
		mu 0 3 12 19 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".dr" 1;
createNode transform -n "pCube14";
	rename -uid "E5EAA099-4ADE-DF83-DEAF-1D812A9062EA";
createNode mesh -n "pCubeShape14" -p "pCube14";
	rename -uid "62FC6BD7-41F6-3C48-EE84-5A91C159A9C4";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ugsdt" no;
	setAttr ".dr" 1;
createNode mesh -n "polySurfaceShape13" -p "pCube14";
	rename -uid "C2DD8264-4D0B-5620-209E-3B9CE69797B2";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 20 ".uvst[0].uvsp[0:19]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25 0.5 0.125 0.5 0.375 0.5 0.625 0.5 0.875 0.75 0.125
		 0.25 0.125;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".ugsdt" no;
	setAttr -s 14 ".vt[0:13]"  -0.5 -0.50000048 0.5 0.5 -0.50000048 0.5
		 -0.5 0.49999952 0.5 0.5 0.49999952 0.5 -0.5 0.49999952 -0.5 0.5 0.49999952 -0.5 -0.5 -0.50000048 -0.5
		 0.5 -0.50000048 -0.5 0 0 3.59867573 0 3.59867573 9.5367432e-07 0 0 -3.5986762 0 -3.5986762 0
		 3.59867477 0 0 -3.59867668 0 9.5367432e-07;
	setAttr -s 36 ".ed[0:35]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0 0 8 1 8 3 1 1 8 1 2 8 1 2 9 1 9 5 1 3 9 1 4 9 1 4 10 1
		 10 7 1 5 10 1 6 10 1 6 11 1 11 1 1 7 11 1 0 11 1 1 12 1 12 5 1 7 12 1 3 12 1 6 13 1
		 13 2 1 0 13 1 4 13 1;
	setAttr -s 24 -ch 72 ".fc[0:23]" -type "polyFaces" 
		f 3 15 13 -2
		mu 0 3 2 14 3
		f 3 19 17 -3
		mu 0 3 4 15 5
		f 3 23 21 -4
		mu 0 3 6 16 7
		f 3 27 25 -1
		mu 0 3 8 17 9
		f 3 31 29 -8
		mu 0 3 3 18 11
		f 3 35 33 6
		mu 0 3 13 19 2
		f 3 0 14 -13
		mu 0 3 0 1 14
		f 3 -15 5 -14
		mu 0 3 14 1 3
		f 3 12 -16 -5
		mu 0 3 0 14 2
		f 3 1 18 -17
		mu 0 3 2 3 15
		f 3 -19 7 -18
		mu 0 3 15 3 5
		f 3 16 -20 -7
		mu 0 3 2 15 4
		f 3 2 22 -21
		mu 0 3 4 5 16
		f 3 -23 9 -22
		mu 0 3 16 5 7
		f 3 20 -24 -9
		mu 0 3 4 16 6
		f 3 3 26 -25
		mu 0 3 6 7 17
		f 3 -27 11 -26
		mu 0 3 17 7 9
		f 3 24 -28 -11
		mu 0 3 6 17 8
		f 3 -12 30 -29
		mu 0 3 1 10 18
		f 3 -31 -10 -30
		mu 0 3 18 10 11
		f 3 28 -32 -6
		mu 0 3 1 18 3
		f 3 10 34 -33
		mu 0 3 12 0 19
		f 3 -35 4 -34
		mu 0 3 19 0 2
		f 3 32 -36 8
		mu 0 3 12 19 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".dr" 1;
createNode lightLinker -s -n "lightLinker1";
	rename -uid "EEC2749A-4FAF-2DAC-9EA3-0C9D9A792669";
	setAttr -s 6 ".lnk";
	setAttr -s 6 ".slnk";
createNode displayLayerManager -n "layerManager";
	rename -uid "7508A5AD-4A73-F612-9D45-82A4A69441E9";
createNode displayLayer -n "defaultLayer";
	rename -uid "210155D8-49B0-0453-121C-3686FFFBF90D";
createNode renderLayerManager -n "renderLayerManager";
	rename -uid "1EEB4AAD-4157-9CB8-DAB1-D28265699CB4";
createNode renderLayer -n "defaultRenderLayer";
	rename -uid "1A650EAD-4006-F702-2A13-8686B26F1F32";
	setAttr ".g" yes;
createNode polyTorus -n "polyTorus1";
	rename -uid "6E93C038-484F-AB79-6B60-CA9C12E33772";
	setAttr ".sr" 0.1;
	setAttr ".sa" 50;
createNode polyCube -n "polyCube1";
	rename -uid "0C94E47F-4BEE-819E-C884-FCAD6CD01EA2";
	setAttr ".cuv" 4;
createNode polyExtrudeFace -n "polyExtrudeFace1";
	rename -uid "CA6C624D-4EEC-D804-03EB-AA80F2A24D02";
	setAttr ".ics" -type "componentList" 2 "f[1]" "f[3:5]";
	setAttr ".ix" -type "matrix" 0.63864301866909967 0 0 0 0 0.63864301866909967 0 0
		 0 0 0.63864301866909967 0 0 0 0 1;
	setAttr ".ws" yes;
	setAttr ".rs" 38315;
	setAttr ".lt" -type "double3" 0 4.4363325753453858e-18 1.162648039048169 ;
	setAttr ".kft" no;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.31932150933454984 -0.31932150933454984 -0.31932150933454984 ;
	setAttr ".cbx" -type "double3" 0.31932150933454984 0.31932150933454984 0.31932150933454984 ;
createNode polyUnite -n "polyUnite1";
	rename -uid "B35F42DE-4FC0-AEC0-F1D7-1DA575FED3CD";
	setAttr -s 2 ".ip";
	setAttr -s 2 ".im";
createNode groupId -n "groupId1";
	rename -uid "E12B0F24-4DC7-4E50-C0AB-79AC3EFEB993";
	setAttr ".ihi" 0;
createNode groupParts -n "groupParts1";
	rename -uid "3A6E3EDD-48A2-8189-1106-BE90F14B1C35";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 1 "f[0:999]";
createNode groupId -n "groupId2";
	rename -uid "111A05E6-4404-0660-DF37-24BE79ABCEA8";
	setAttr ".ihi" 0;
createNode groupId -n "groupId3";
	rename -uid "FB9DD8C1-4A0C-B198-FEB2-52BE1DEE23D0";
	setAttr ".ihi" 0;
createNode groupParts -n "groupParts2";
	rename -uid "43FF1672-4F03-0C04-ECF9-98BBFCA708CF";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 1 "f[0:21]";
createNode groupId -n "groupId4";
	rename -uid "2E5F12D2-42D1-D505-FEFF-FE880A612D63";
	setAttr ".ihi" 0;
createNode shadingEngine -n "phongE1SG";
	rename -uid "E941F173-4A53-A204-EC9C-AB94DCA75C1E";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo1";
	rename -uid "7F8C53C7-4D4F-70B9-391D-488804B72BE0";
createNode script -n "uiConfigurationScriptNode";
	rename -uid "9542F2D2-46DF-EF80-EAB8-F29F1EED892D";
	setAttr ".b" -type "string" (
		"// Maya Mel UI Configuration File.\n//\n//  This script is machine generated.  Edit at your own risk.\n//\n//\n\nglobal string $gMainPane;\nif (`paneLayout -exists $gMainPane`) {\n\n\tglobal int $gUseScenePanelConfig;\n\tint    $useSceneConfig = $gUseScenePanelConfig;\n\tint    $menusOkayInPanels = `optionVar -q allowMenusInPanels`;\tint    $nVisPanes = `paneLayout -q -nvp $gMainPane`;\n\tint    $nPanes = 0;\n\tstring $editorName;\n\tstring $panelName;\n\tstring $itemFilterName;\n\tstring $panelConfig;\n\n\t//\n\t//  get current state of the UI\n\t//\n\tsceneUIReplacement -update $gMainPane;\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Top View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Top View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"top\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"wireframe\" \n            -activeOnly 0\n"
		+ "            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 1\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n"
		+ "            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n"
		+ "            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1\n            -height 1\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Side View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Side View\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"side\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"wireframe\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 1\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n"
		+ "            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n"
		+ "            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1\n            -height 1\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n"
		+ "\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Front View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Front View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"front\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"wireframe\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 1\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n"
		+ "            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n"
		+ "            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1\n            -height 1\n"
		+ "            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Persp View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Persp View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"persp\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 1\n            -backfaceCulling 0\n"
		+ "            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 1\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n"
		+ "            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 0\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n"
		+ "            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 945\n            -height 723\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"Outliner\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\toutlinerPanel -edit -l (localizedPanelLabel(\"Outliner\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -docTag \"isolOutln_fromSeln\" \n            -showShapes 0\n            -showAssignedMaterials 0\n            -showTimeEditor 1\n            -showReferenceNodes 0\n            -showReferenceMembers 0\n"
		+ "            -showAttributes 0\n            -showConnected 0\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n            -organizeByClip 1\n            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n            -showParentContainers 0\n            -showContainerContents 1\n            -ignoreDagHierarchy 0\n            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n            -highlightActive 1\n            -autoSelectNewObjects 0\n            -doNotSelectNewObjects 0\n            -dropIsParent 1\n            -transmitFilters 0\n            -setFilter \"defaultSetFilter\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n"
		+ "            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n            -longNames 0\n            -niceNames 1\n            -showNamespace 1\n            -showPinIcons 0\n            -mapMotionTrails 0\n            -ignoreHiddenAttribute 0\n            -ignoreOutlinerColor 0\n            -renderFilterVisible 0\n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"graphEditor\" (localizedPanelLabel(\"Graph Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Graph Editor\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showAssignedMaterials 0\n                -showTimeEditor 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -organizeByClip 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 1\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showParentContainers 1\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 1\n                -showCompounds 0\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n"
		+ "                -highlightActive 0\n                -autoSelectNewObjects 1\n                -doNotSelectNewObjects 0\n                -dropIsParent 1\n                -transmitFilters 1\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 1\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n"
		+ "                -renderFilterVisible 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"GraphEd\");\n            animCurveEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 1\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 1\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -showResults \"off\" \n                -showBufferCurves \"off\" \n                -smoothness \"fine\" \n                -resultSamples 1\n                -resultScreenSamples 0\n                -resultUpdate \"delayed\" \n                -showUpstreamCurves 1\n                -showCurveNames 0\n                -showActiveCurveNames 0\n                -stackedCurves 0\n                -stackedCurvesMin -1\n                -stackedCurvesMax 1\n                -stackedCurvesSpace 0.2\n                -displayNormalized 0\n                -preSelectionHighlight 0\n                -constrainDrag 0\n"
		+ "                -classicMode 1\n                -valueLinesToggle 1\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dopeSheetPanel\" (localizedPanelLabel(\"Dope Sheet\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dope Sheet\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showAssignedMaterials 0\n                -showTimeEditor 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -organizeByClip 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 0\n                -showDagOnly 0\n"
		+ "                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showParentContainers 1\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 0\n                -showCompounds 1\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 0\n                -doNotSelectNewObjects 1\n                -dropIsParent 1\n                -transmitFilters 0\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n"
		+ "                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 0\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                -renderFilterVisible 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"DopeSheetEd\");\n            dopeSheetEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -outliner \"dopeSheetPanel1OutlineEd\" \n                -showSummary 1\n                -showScene 0\n                -hierarchyBelow 0\n"
		+ "                -showTicks 1\n                -selectionWindow 0 0 0 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"clipEditorPanel\" (localizedPanelLabel(\"Trax Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Trax Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = clipEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -initialized 0\n                -manageSequencer 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"sequenceEditorPanel\" (localizedPanelLabel(\"Camera Sequencer\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Camera Sequencer\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = sequenceEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -displayValues 0\n                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -initialized 0\n                -manageSequencer 1 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperGraphPanel\" (localizedPanelLabel(\"Hypergraph Hierarchy\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypergraph Hierarchy\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\n\t\t\t$editorName = ($panelName+\"HyperGraphEd\");\n            hyperGraph -e \n                -graphLayoutStyle \"hierarchicalLayout\" \n                -orientation \"horiz\" \n                -mergeConnections 0\n                -zoom 1\n                -animateTransition 0\n                -showRelationships 1\n                -showShapes 0\n                -showDeformers 0\n                -showExpressions 0\n                -showConstraints 0\n                -showConnectionFromSelected 0\n                -showConnectionToSelected 0\n                -showConstraintLabels 0\n                -showUnderworld 0\n                -showInvisible 0\n                -transitionFrames 1\n                -opaqueContainers 0\n                -freeform 0\n                -imagePosition 0 0 \n                -imageScale 1\n                -imageEnabled 0\n                -graphType \"DAG\" \n                -heatMapDisplay 0\n                -updateSelection 1\n                -updateNodeAdded 1\n                -useDrawOverrideColor 0\n                -limitGraphTraversal -1\n"
		+ "                -range 0 0 \n                -iconSize \"smallIcons\" \n                -showCachedConnections 0\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperShadePanel\" (localizedPanelLabel(\"Hypershade\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypershade\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"visorPanel\" (localizedPanelLabel(\"Visor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Visor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"createNodePanel\" (localizedPanelLabel(\"Create Node\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n"
		+ "\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Create Node\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"polyTexturePlacementPanel\" (localizedPanelLabel(\"UV Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"UV Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"renderWindowPanel\" (localizedPanelLabel(\"Render View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Render View\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynRelEdPanel\" (localizedPanelLabel(\"Dynamic Relationships\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n"
		+ "\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dynamic Relationships\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"relationshipPanel\" (localizedPanelLabel(\"Relationship Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Relationship Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"referenceEditorPanel\" (localizedPanelLabel(\"Reference Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Reference Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"componentEditorPanel\" (localizedPanelLabel(\"Component Editor\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Component Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynPaintScriptedPanelType\" (localizedPanelLabel(\"Paint Effects\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Paint Effects\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"scriptEditorPanel\" (localizedPanelLabel(\"Script Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Script Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"contentBrowserPanel\" (localizedPanelLabel(\"Content Browser\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Content Browser\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"nodeEditorPanel\" (localizedPanelLabel(\"Node Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Node Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"NodeEditorEd\");\n            nodeEditor -e \n                -allAttributes 0\n                -allNodes 0\n                -autoSizeNodes 1\n                -consistentNameSize 1\n                -createNodeCommand \"nodeEdCreateNodeCommand\" \n                -connectNodeOnCreation 0\n                -connectOnDrop 0\n                -highlightConnections 0\n                -copyConnectionsOnPaste 0\n                -defaultPinnedState 0\n                -additiveGraphingMode 0\n                -settingsChangedCallback \"nodeEdSyncControls\" \n"
		+ "                -traversalDepthLimit -1\n                -keyPressCommand \"nodeEdKeyPressCommand\" \n                -nodeTitleMode \"name\" \n                -gridSnap 0\n                -gridVisibility 1\n                -crosshairOnEdgeDragging 0\n                -popupMenuScript \"nodeEdBuildPanelMenus\" \n                -showNamespace 1\n                -showShapes 1\n                -showSGShapes 0\n                -showTransforms 1\n                -useAssets 1\n                -syncedSelection 1\n                -extendToShapes 1\n                -activeTab -1\n                -editorMode \"default\" \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"blendShapePanel\" (localizedPanelLabel(\"Blend Shape\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tblendShapePanel -edit -l (localizedPanelLabel(\"Blend Shape\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n"
		+ "\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"shapePanel\" (localizedPanelLabel(\"Shape Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tshapePanel -edit -l (localizedPanelLabel(\"Shape Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"posePanel\" (localizedPanelLabel(\"Pose Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tposePanel -edit -l (localizedPanelLabel(\"Pose Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"profilerPanel\" (localizedPanelLabel(\"Profiler Tool\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Profiler Tool\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"timeEditorPanel\" (localizedPanelLabel(\"Time Editor\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Time Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"ToggledOutliner\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\toutlinerPanel -edit -l (localizedPanelLabel(\"ToggledOutliner\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -showShapes 0\n            -showAssignedMaterials 0\n            -showTimeEditor 1\n            -showReferenceNodes 1\n            -showReferenceMembers 1\n            -showAttributes 0\n            -showConnected 0\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n            -organizeByClip 1\n            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n"
		+ "            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n            -showParentContainers 0\n            -showContainerContents 1\n            -ignoreDagHierarchy 0\n            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n            -highlightActive 1\n            -autoSelectNewObjects 0\n            -doNotSelectNewObjects 0\n            -dropIsParent 1\n            -transmitFilters 0\n            -setFilter \"defaultSetFilter\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n            -isSet 0\n            -isSetMember 0\n            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n"
		+ "            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n            -longNames 0\n            -niceNames 1\n            -showNamespace 1\n            -showPinIcons 0\n            -mapMotionTrails 0\n            -ignoreHiddenAttribute 0\n            -ignoreOutlinerColor 0\n            -renderFilterVisible 0\n            -renderFilterIndex 0\n            -selectionOrder \"chronological\" \n            -expandAttribute 0\n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\tif ($useSceneConfig) {\n        string $configName = `getPanel -cwl (localizedPanelLabel(\"Current Layout\"))`;\n        if (\"\" != $configName) {\n\t\t\tpanelConfiguration -edit -label (localizedPanelLabel(\"Current Layout\")) \n\t\t\t\t-userCreated false\n\t\t\t\t-defaultImage \"\"\n\t\t\t\t-image \"\"\n\t\t\t\t-sc false\n\t\t\t\t-configString \"global string $gMainPane; paneLayout -e -cn \\\"single\\\" -ps 1 100 100 $gMainPane;\"\n\t\t\t\t-removeAllPanels\n\t\t\t\t-ap false\n"
		+ "\t\t\t\t\t(localizedPanelLabel(\"Persp View\")) \n\t\t\t\t\t\"modelPanel\"\n"
		+ "\t\t\t\t\t\"$panelName = `modelPanel -unParent -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels `;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 1\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 1\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 16384\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -controllers 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 0\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 945\\n    -height 723\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t\t\"modelPanel -edit -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels  $panelName;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 1\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 1\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 16384\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -controllers 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 0\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 945\\n    -height 723\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t$configName;\n\n            setNamedPanelLayout (localizedPanelLabel(\"Current Layout\"));\n        }\n\n        panelHistory -e -clear mainPanelHistory;\n        sceneUIReplacement -clear;\n\t}\n\n\ngrid -spacing 5 -size 12 -divisions 10 -displayAxes yes -displayGridLines yes -displayDivisionLines yes -displayPerspectiveLabels no -displayOrthographicLabels no -displayAxesBold yes -perspectiveLabelPosition axis -orthographicLabelPosition edge;\nviewManip -drawCompass 0 -compassAngle 0 -frontParameters \"\" -homeParameters \"\" -selectionLockParameters \"\";\n}\n");
	setAttr ".st" 3;
createNode script -n "sceneConfigurationScriptNode";
	rename -uid "99A060C1-418E-7BF3-B749-FC94A902EB48";
	setAttr ".b" -type "string" "playbackOptions -min 1 -max 48 -ast 1 -aet 48 ";
	setAttr ".st" 6;
createNode polyCube -n "polyCube2";
	rename -uid "6A0401F6-4240-1E1E-0D9A-AA99F0746307";
	setAttr ".cuv" 4;
createNode polyPoke -n "polyPoke1";
	rename -uid "F1473CA7-42AF-46BD-F183-18975C852E78";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "f[0:5]";
	setAttr ".ix" -type "matrix" 0.15791535891786865 0 0 0 0 0.15791535891786865 0 0
		 0 0 0.15791535891786865 0 -1.8358005307567551 0.81859208683273676 1.3220221966215828 1;
	setAttr ".ws" yes;
	setAttr ".lt" -type "double3" 2.2204460492503131e-16 0 0.48932855086726068 ;
createNode polySmoothFace -n "polySmoothFace1";
	rename -uid "0956A28E-4A40-7684-0D7A-109C7916529F";
	setAttr ".ics" -type "componentList" 1 "f[*]";
	setAttr ".ost" yes;
	setAttr ".suv" yes;
	setAttr ".ps" 0.10000000149011612;
	setAttr ".ro" 1;
	setAttr ".ma" yes;
	setAttr ".m08" yes;
	setAttr ".ovf" yes;
createNode polySmoothFace -n "polySmoothFace2";
	rename -uid "9CAF813B-4D05-409B-D039-FDB8A9AAC0DE";
	setAttr ".ics" -type "componentList" 1 "f[*]";
	setAttr ".ost" yes;
	setAttr ".suv" yes;
	setAttr ".ps" 0.10000000149011612;
	setAttr ".ro" 1;
	setAttr ".ma" yes;
	setAttr ".m08" yes;
	setAttr ".ovf" yes;
createNode polySmoothFace -n "polySmoothFace3";
	rename -uid "5C67A00A-4548-9352-6C32-5299ED71A7AE";
	setAttr ".ics" -type "componentList" 1 "f[*]";
	setAttr ".ost" yes;
	setAttr ".suv" yes;
	setAttr ".ps" 0.10000000149011612;
	setAttr ".ro" 1;
	setAttr ".ma" yes;
	setAttr ".m08" yes;
	setAttr ".ovf" yes;
createNode polySmoothFace -n "polySmoothFace4";
	rename -uid "25C6ABB7-4491-A13E-5926-279CB79F0761";
	setAttr ".ics" -type "componentList" 1 "f[*]";
	setAttr ".ost" yes;
	setAttr ".suv" yes;
	setAttr ".ps" 0.10000000149011612;
	setAttr ".ro" 1;
	setAttr ".ma" yes;
	setAttr ".m08" yes;
	setAttr ".ovf" yes;
createNode polySmoothFace -n "polySmoothFace5";
	rename -uid "F1159043-48AE-64CF-E923-A5B2C0E6A037";
	setAttr ".ics" -type "componentList" 1 "f[*]";
	setAttr ".ost" yes;
	setAttr ".suv" yes;
	setAttr ".ps" 0.10000000149011612;
	setAttr ".ro" 1;
	setAttr ".ma" yes;
	setAttr ".m08" yes;
	setAttr ".ovf" yes;
createNode polySmoothFace -n "polySmoothFace6";
	rename -uid "5BB2D7F5-4DD7-2682-8EC8-EBBA5989558C";
	setAttr ".ics" -type "componentList" 1 "f[*]";
	setAttr ".ost" yes;
	setAttr ".suv" yes;
	setAttr ".ps" 0.10000000149011612;
	setAttr ".ro" 1;
	setAttr ".ma" yes;
	setAttr ".m08" yes;
	setAttr ".ovf" yes;
createNode polySmoothFace -n "polySmoothFace7";
	rename -uid "46BC193A-4D33-96BF-AB39-B5A146713221";
	setAttr ".ics" -type "componentList" 1 "f[*]";
	setAttr ".ost" yes;
	setAttr ".suv" yes;
	setAttr ".ps" 0.10000000149011612;
	setAttr ".ro" 1;
	setAttr ".ma" yes;
	setAttr ".m08" yes;
	setAttr ".ovf" yes;
createNode polySmoothFace -n "polySmoothFace8";
	rename -uid "2C956C4A-4F10-7DFF-701F-3BB56E3095A9";
	setAttr ".ics" -type "componentList" 1 "f[*]";
	setAttr ".ost" yes;
	setAttr ".suv" yes;
	setAttr ".ps" 0.10000000149011612;
	setAttr ".ro" 1;
	setAttr ".ma" yes;
	setAttr ".m08" yes;
	setAttr ".ovf" yes;
createNode polySmoothFace -n "polySmoothFace9";
	rename -uid "C58AB56C-4E28-445C-21A1-FB9CF6C5EFB9";
	setAttr ".ics" -type "componentList" 1 "f[*]";
	setAttr ".ost" yes;
	setAttr ".suv" yes;
	setAttr ".ps" 0.10000000149011612;
	setAttr ".ro" 1;
	setAttr ".ma" yes;
	setAttr ".m08" yes;
	setAttr ".ovf" yes;
createNode polySmoothFace -n "polySmoothFace10";
	rename -uid "7515BEF6-4EF9-A534-C210-118395A34F39";
	setAttr ".ics" -type "componentList" 1 "f[*]";
	setAttr ".ost" yes;
	setAttr ".suv" yes;
	setAttr ".ps" 0.10000000149011612;
	setAttr ".ro" 1;
	setAttr ".ma" yes;
	setAttr ".m08" yes;
	setAttr ".ovf" yes;
createNode polySmoothFace -n "polySmoothFace11";
	rename -uid "E74023A1-4503-48DD-27D2-27B80C1F8912";
	setAttr ".ics" -type "componentList" 1 "f[*]";
	setAttr ".ost" yes;
	setAttr ".suv" yes;
	setAttr ".ps" 0.10000000149011612;
	setAttr ".ro" 1;
	setAttr ".ma" yes;
	setAttr ".m08" yes;
	setAttr ".ovf" yes;
createNode polySmoothFace -n "polySmoothFace12";
	rename -uid "7760D57A-4B36-7CF9-C252-09AC2FFB132A";
	setAttr ".ics" -type "componentList" 1 "f[*]";
	setAttr ".ost" yes;
	setAttr ".suv" yes;
	setAttr ".ps" 0.10000000149011612;
	setAttr ".ro" 1;
	setAttr ".ma" yes;
	setAttr ".m08" yes;
	setAttr ".ovf" yes;
createNode polySmoothFace -n "polySmoothFace13";
	rename -uid "1EDE7F97-4C31-6724-AFE0-BF814E7194D3";
	setAttr ".ics" -type "componentList" 1 "f[*]";
	setAttr ".ost" yes;
	setAttr ".suv" yes;
	setAttr ".ps" 0.10000000149011612;
	setAttr ".ro" 1;
	setAttr ".ma" yes;
	setAttr ".m08" yes;
	setAttr ".ovf" yes;
createNode phongE -n "phongE2";
	rename -uid "18438979-4255-0EE1-70C2-F1B2F3C5E15A";
	setAttr ".c" -type "float3" 0 0.64957654 0 ;
createNode shadingEngine -n "phongE2SG";
	rename -uid "7CB75CE7-4B02-4A14-1A01-AA944BE9946E";
	setAttr ".ihi" 0;
	setAttr -s 5 ".dsm";
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo2";
	rename -uid "F742465F-428B-4903-C373-928FE7A9A9F7";
createNode phongE -n "phongE3";
	rename -uid "C9E0FFA5-4C82-B49C-7A1D-B3867D7BCED5";
	setAttr ".c" -type "float3" 0.75 1 0 ;
	setAttr ".gi" 0.17094017565250397;
createNode shadingEngine -n "phongE3SG";
	rename -uid "0FA56CC8-425F-34DE-B077-12A94BC55519";
	setAttr ".ihi" 0;
	setAttr -s 5 ".dsm";
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo3";
	rename -uid "2476C581-4C26-23F6-2D00-878F4E3A44D0";
createNode phongE -n "phongE4";
	rename -uid "4DF0D796-4F02-24B0-38BC-42BCBA4E4C4F";
	setAttr ".c" -type "float3" 0 1 0.5333333 ;
	setAttr ".gi" 0.085000000894069672;
createNode shadingEngine -n "phongE4SG";
	rename -uid "AF0A3FF2-4A5D-B3C9-5036-7A9EC8C3E16C";
	setAttr ".ihi" 0;
	setAttr -s 3 ".dsm";
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo4";
	rename -uid "C3B1B867-4789-53BA-762E-DD9830FB9FBA";
createNode animCurveTL -n "pCube10_translateX";
	rename -uid "BE02EBA4-481D-D285-6234-F5B359841259";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 -1.2170876433187532 24 -1.2170876433187532
		 48 -1.2170876433187532;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube10_translateY";
	rename -uid "B100CFF5-46A1-5588-D721-288C4F2FD612";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.16340929679078742 24 2.4502532018604946
		 48 0.16340929679078742;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube10_translateZ";
	rename -uid "A227E2E3-4574-24EA-42E2-94866A3BFB1C";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 -2.1371375570508691 24 -2.1371375570508691
		 48 -2.1371375570508691;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube11_translateX";
	rename -uid "A926C314-46E7-5F78-E534-F4ACB2F52D2C";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 -2.835650643741114 24 -2.835650643741114
		 48 -2.835650643741114;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube11_translateY";
	rename -uid "DAA90149-42B2-860A-31A8-2F85357E3149";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 -1.3653094022571062 24 0.95529793618728998
		 48 -1.3653094022571062;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube11_translateZ";
	rename -uid "3769D46E-4DD1-AF24-0C90-3DAB9503B97A";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.2113264333422597 24 0.2113264333422597
		 48 0.2113264333422597;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube12_translateX";
	rename -uid "AE9BEDB8-4A19-27DB-6419-36A0D36C1E8A";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 -0.41538711789589744 24 -0.41538711789589744
		 48 -0.41538711789589744;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube12_translateY";
	rename -uid "28BB1623-475B-CB18-E186-59A2195E7675";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 -1.7966568698548093 24 -0.019880033744927195
		 48 -1.7966568698548093;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube12_translateZ";
	rename -uid "E615D597-424A-6CBB-65B7-4493FA1A4F69";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 1.5633641183739952 24 1.5633641183739952
		 48 1.5633641183739952;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube13_translateX";
	rename -uid "E0F3F588-4209-447A-AB15-83AA3E767CDD";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.40540151527512291 24 0.40540151527512291
		 48 0.40540151527512291;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube13_translateY";
	rename -uid "32E2F53E-476B-679A-F132-4FAAC77E7942";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 1.1548381136405945 24 2.9316149497504767
		 48 1.1548381136405945;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube13_translateZ";
	rename -uid "D30DAAF8-4A49-E6E6-F9F7-EDBE743C1AE7";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 -0.89615538866153699 24 -0.89615538866153699
		 48 -0.89615538866153699;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube14_translateX";
	rename -uid "9D218524-4872-C2B4-1401-C2B9357D0087";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 -2.5809666441079031 24 -2.5809666441079031
		 48 -2.5809666441079031;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube14_translateY";
	rename -uid "BE2841B5-454C-F197-F38F-E29BF34BE7F8";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 -1.7966568698548093 24 1.5946431434736554
		 48 -1.7966568698548093;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube14_translateZ";
	rename -uid "F66FEE17-45B1-FB05-19E4-18AD2163C83E";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 1.563364118373995 24 1.563364118373995
		 48 1.563364118373995;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube2_translateX";
	rename -uid "848EC285-4DB3-F556-6CF0-B09E96B979F6";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 -1.8358005307567551 24 -1.8358005307567551
		 48 -1.8358005307567551;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube2_translateY";
	rename -uid "448A8EC8-4048-1D39-615B-F88D7ACECE6F";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.1582511425887132 24 2.5253116148050472
		 48 0.1582511425887132;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube2_translateZ";
	rename -uid "3AB23470-4274-1B75-307E-0F9A788DCF0A";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 1.3220221966215828 24 1.3220221966215828
		 48 1.3220221966215828;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube3_translateX";
	rename -uid "95825E16-44FE-D189-5CDD-6ABAF0DBBCCD";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.77066802131159218 24 0.77066802131159218
		 48 0.77066802131159218;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube3_translateY";
	rename -uid "33126441-41B7-179D-3AE4-80817B339D63";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 1.2211163974255459 24 3.5143444002804984
		 48 1.2211163974255459;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube3_translateZ";
	rename -uid "47065589-4D18-3E7E-BA62-4A977FE40052";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.814384239373519 24 0.814384239373519
		 48 0.814384239373519;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube4_translateX";
	rename -uid "32E2EF2E-4345-473E-D232-B5B3E5950A6E";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 1.5506879801649203 24 1.5506879801649203
		 48 1.5506879801649203;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube4_translateY";
	rename -uid "76E67638-41EA-1A82-71BB-C29D92445176";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 -2.7498446409346387 24 -0.46332277707578129
		 48 -2.7498446409346387;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube4_translateZ";
	rename -uid "C487213E-4A22-A1F2-FB9E-3EB75B7A836E";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 -0.71353799661994521 24 -0.71353799661994521
		 48 -0.71353799661994521;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube5_translateX";
	rename -uid "05171995-4CB9-B12A-97CD-1C81D9D8DF31";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 -2.8203854945760836 24 -2.8203854945760836
		 48 -2.8203854945760836;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube5_translateY";
	rename -uid "DFD2470E-41F5-19E4-AC8C-C2A7E30BD285";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 -2.1224677872873352 24 -0.70146900037046356
		 48 -2.1224677872873352;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube5_translateZ";
	rename -uid "4F869A92-4C62-766D-6DF1-E3B6DF46B2E8";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 -0.92845551824867467 24 -0.92845551824867467
		 48 -0.92845551824867467;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube6_translateX";
	rename -uid "01C25050-4101-672D-38B6-409F2F026B4B";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 -0.81623738060732087 24 -0.81623738060732087
		 48 -0.81623738060732087;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube6_translateY";
	rename -uid "E6C58F02-4BE3-968A-3B61-C8B098091DB1";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 -0.26962857723556555 24 2.433164581379232
		 48 -0.26962857723556555;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube6_translateZ";
	rename -uid "DA8BE385-49E0-4397-89F0-0EBF847E327D";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 -0.7978684574431949 24 -0.7978684574431949
		 48 -0.7978684574431949;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube7_translateX";
	rename -uid "48FF0B6A-4B1A-D997-E7EA-729B49E7A658";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.74898745474206141 24 0.74898745474206141
		 48 0.74898745474206141;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube7_translateY";
	rename -uid "A19A1618-41BD-A40F-70EA-759219CFE733";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 -1.7966568698548093 24 0.41335220681233187
		 48 -1.7966568698548093;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube7_translateZ";
	rename -uid "E440EE2D-4895-BC41-13D5-C194DEE66628";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 1.4870116873813417 24 1.4870116873813417
		 48 1.4870116873813417;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube8_translateX";
	rename -uid "4DC33A2A-41BF-C56D-7719-BB923BB3FF01";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 2.2476120484459239 24 2.2476120484459239
		 48 2.2476120484459239;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube8_translateY";
	rename -uid "709D9F1D-423A-A805-D224-BD899ED5A4B6";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 -1.3680433000034595 24 1.5083580980981766
		 48 -1.3680433000034595;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube8_translateZ";
	rename -uid "59C44897-4A93-265F-A540-C3BE348ACCDE";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 -1.1552777796389422 24 -1.1552777796389422
		 48 -1.1552777796389422;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube9_translateX";
	rename -uid "FABA8BFF-4D2F-E144-BC4F-77A9591B3AD9";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 3.1922652465069552 24 3.1922652465069552
		 48 3.1922652465069552;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube9_translateY";
	rename -uid "6F089CE7-457D-74EF-1625-B296AF114A7C";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 -0.73685365184294671 24 0.59085897826216649
		 48 -0.73685365184294671;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "pCube9_translateZ";
	rename -uid "11C245C1-4908-5D3C-F912-7FA68E99A5FC";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.84968724946333729 24 0.84968724946333729
		 48 0.84968724946333729;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "polySurface1_translateX";
	rename -uid "ACFFE491-4746-2D8A-D0C6-CB933EB9720C";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "polySurface1_translateY";
	rename -uid "6EE593A9-497F-01F8-9332-478F60F1DCCB";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 -0.66034094424402356 24 1.1164358918658586
		 48 -0.66034094424402356;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTL -n "polySurface1_translateZ";
	rename -uid "386C640D-4E3D-34D3-7544-C48F810F8D71";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube2_visibility";
	rename -uid "E92A0617-4743-36ED-C298-1DB3A7469493";
	setAttr ".tan" 5;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 1 24 1 48 1;
	setAttr -s 3 ".kit[0:2]"  9 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
createNode animCurveTA -n "pCube2_rotateX";
	rename -uid "C179A9E0-4276-C92C-64FB-F5BA8B6F4269";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTA -n "pCube2_rotateY";
	rename -uid "34B435C4-4ED5-C582-A040-1C96E22FB61D";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTA -n "pCube2_rotateZ";
	rename -uid "210D081F-466A-B3C3-29A2-369369DBA9C5";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube2_scaleX";
	rename -uid "93D5B359-4EA9-5951-2661-C0BCFE1B38BC";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube2_scaleY";
	rename -uid "24C1475C-4A7E-ECD2-0251-06A820E32AB0";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube2_scaleZ";
	rename -uid "C0DD08C9-4CCE-1368-0FE1-DDBB6552A1D9";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube3_visibility";
	rename -uid "6A60DE89-4F98-3C4E-5E1E-69BBBD0F59B4";
	setAttr ".tan" 5;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 1 24 1 48 1;
	setAttr -s 3 ".kit[0:2]"  9 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
createNode animCurveTA -n "pCube3_rotateX";
	rename -uid "DF634135-4BEB-95F7-1FD1-A69E1BFFC0EC";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTA -n "pCube3_rotateY";
	rename -uid "0247585B-4DA4-8008-FAC6-01B4463FD0AB";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTA -n "pCube3_rotateZ";
	rename -uid "B38B57EB-446F-8110-EB85-E789477D7B2D";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube3_scaleX";
	rename -uid "5F27215C-48D1-182F-2206-61B1B1F89919";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube3_scaleY";
	rename -uid "DE95EDFA-48C9-73E4-28F8-CAB0DDF1F986";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube3_scaleZ";
	rename -uid "7B6F85B2-415E-F270-5D5A-83A17A90D67D";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube4_visibility";
	rename -uid "042B8B18-43DE-0EC5-5568-CA9C2DD01352";
	setAttr ".tan" 5;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 1 24 1 48 1;
	setAttr -s 3 ".kit[0:2]"  9 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
createNode animCurveTA -n "pCube4_rotateX";
	rename -uid "A30F77C0-46BE-751F-DA6B-4D8081EAB215";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTA -n "pCube4_rotateY";
	rename -uid "95913734-4A93-0352-F863-7DA5C9A5B058";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTA -n "pCube4_rotateZ";
	rename -uid "D4AE631C-4EF2-31E4-5B29-0B85C968268B";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube4_scaleX";
	rename -uid "43F9538A-4255-4107-9A34-AD96D7F3E9CE";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube4_scaleY";
	rename -uid "E7AC05F7-430A-F57C-91F2-1AAF9B7BB82C";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube4_scaleZ";
	rename -uid "959708CF-47E7-8266-CE0B-408951778E98";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube5_visibility";
	rename -uid "FB498E23-4C69-C9F2-515F-C09D9700477C";
	setAttr ".tan" 5;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 1 24 1 48 1;
	setAttr -s 3 ".kit[0:2]"  9 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
createNode animCurveTA -n "pCube5_rotateX";
	rename -uid "284A0DDB-40C0-AFC0-713A-C0AA18D28CB1";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTA -n "pCube5_rotateY";
	rename -uid "24EFBF9B-410C-6A73-8766-48B699D65234";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTA -n "pCube5_rotateZ";
	rename -uid "C180463D-4455-63E1-7BDA-05824C4AE116";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube5_scaleX";
	rename -uid "27E26F9E-4CBB-993E-2AF7-52A77A4BF53D";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube5_scaleY";
	rename -uid "56ECDEC4-4AA9-CCBC-E95B-CFAF672A982B";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube5_scaleZ";
	rename -uid "3FA92CD5-4FBD-FF3D-627E-509532D7914A";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube6_visibility";
	rename -uid "6F579E5C-46E5-6076-B4F2-B88CAA5A4410";
	setAttr ".tan" 5;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 1 24 1 48 1;
	setAttr -s 3 ".kit[0:2]"  9 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
createNode animCurveTA -n "pCube6_rotateX";
	rename -uid "3EA66FDE-4048-DDEA-5A8C-88B9EA520358";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTA -n "pCube6_rotateY";
	rename -uid "F1CB346D-454E-F4FA-27C6-41A94AAF41C9";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTA -n "pCube6_rotateZ";
	rename -uid "C8FF3D19-43F3-0C0F-3C85-109F567B45B0";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube6_scaleX";
	rename -uid "6D50C6C7-4E97-9139-52B1-00AFDFA215AC";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube6_scaleY";
	rename -uid "944C49FA-4492-5FA4-F7EC-CB978A64C9E5";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube6_scaleZ";
	rename -uid "BA84AE8F-4DE3-AE19-ACE0-038F1E10ADB1";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube7_visibility";
	rename -uid "FFB407AB-48E3-77DE-503C-FD9175E71365";
	setAttr ".tan" 5;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 1 24 1 48 1;
	setAttr -s 3 ".kit[0:2]"  9 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
createNode animCurveTA -n "pCube7_rotateX";
	rename -uid "EB8CB91F-47E0-6462-4D19-83A9DDA60E75";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTA -n "pCube7_rotateY";
	rename -uid "F0A2C06D-4AD3-EFB2-72A6-7195DD585929";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTA -n "pCube7_rotateZ";
	rename -uid "974FFFAD-4BE9-7F46-808F-51A0F6EF64C8";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube7_scaleX";
	rename -uid "0B379DAA-49DD-6869-13A0-CBB7C2010898";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube7_scaleY";
	rename -uid "1986A66D-44DD-79B5-4534-66BEC0F540AE";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube7_scaleZ";
	rename -uid "296E47D7-4D49-123B-A3DD-59846FF0EEBB";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube8_visibility";
	rename -uid "7BE413DA-43B8-F383-5471-119FABB9E97C";
	setAttr ".tan" 5;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 1 24 1 48 1;
	setAttr -s 3 ".kit[0:2]"  9 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
createNode animCurveTA -n "pCube8_rotateX";
	rename -uid "C9C6C56C-4E90-EE41-947F-EBBE371A91D9";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTA -n "pCube8_rotateY";
	rename -uid "A07DBA31-46C5-BB94-2B6F-16813B45C25E";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTA -n "pCube8_rotateZ";
	rename -uid "6C222D30-4E26-2809-2D58-4AB9F99D02FA";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube8_scaleX";
	rename -uid "9E49BA3C-4704-B94D-0B69-05885A394AC6";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube8_scaleY";
	rename -uid "02FB3106-4E90-8E59-6B26-21902E96A89C";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube8_scaleZ";
	rename -uid "ED13CF38-4C2F-5749-D3BE-22B77B3D6AA6";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube9_visibility";
	rename -uid "68F9AC80-450C-C6D9-E564-7A88C01D3948";
	setAttr ".tan" 5;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 1 24 1 48 1;
	setAttr -s 3 ".kit[0:2]"  9 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
createNode animCurveTA -n "pCube9_rotateX";
	rename -uid "D6B8BE93-4AE0-6540-36B6-719D39BB7D0C";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTA -n "pCube9_rotateY";
	rename -uid "01203660-471E-63F8-03C0-0B81FEDF85B4";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTA -n "pCube9_rotateZ";
	rename -uid "A29B0B38-4326-BFA6-286A-EDB90B2B79C5";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube9_scaleX";
	rename -uid "75B32DA8-4D04-3EB4-6ECA-EF8C57812384";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube9_scaleY";
	rename -uid "271E2A1E-4EB0-5D64-B982-FABE06C7237C";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube9_scaleZ";
	rename -uid "7881188B-4F67-751A-2E8F-0DA5DDDCF164";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube10_visibility";
	rename -uid "A8CD3C6D-4955-8F6B-5A66-41A4AB4AC97F";
	setAttr ".tan" 5;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 1 24 1 48 1;
	setAttr -s 3 ".kit[0:2]"  9 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
createNode animCurveTA -n "pCube10_rotateX";
	rename -uid "476C0A43-4F00-C841-214D-B0999EA9CD93";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTA -n "pCube10_rotateY";
	rename -uid "2FD43C88-41F2-20EB-4E52-428E8650FF00";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTA -n "pCube10_rotateZ";
	rename -uid "C3D99647-4E1E-25C4-C280-DA949BF273C4";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube10_scaleX";
	rename -uid "4F4BD3E1-4252-F370-E0F2-06BBFD51C8A5";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube10_scaleY";
	rename -uid "4819B6CE-4473-02AF-F6C3-03A8C55FBD0E";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube10_scaleZ";
	rename -uid "69FE9686-477B-0453-3E0B-9BA461F922E6";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube11_visibility";
	rename -uid "DED1EAD0-4F80-D682-076D-EEBC01DE8369";
	setAttr ".tan" 5;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 1 24 1 48 1;
	setAttr -s 3 ".kit[0:2]"  9 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
createNode animCurveTA -n "pCube11_rotateX";
	rename -uid "B99BC3A9-491F-5183-EC3C-FEBB321DCAA2";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTA -n "pCube11_rotateY";
	rename -uid "9CD5778A-4321-13A8-B323-FD868BD0102C";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTA -n "pCube11_rotateZ";
	rename -uid "6477F7D2-40BF-44D4-CF9F-5CB78C514928";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube11_scaleX";
	rename -uid "D55DA695-48FD-1920-2211-299CC184FEAE";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube11_scaleY";
	rename -uid "4B579BA3-4B0A-A0FA-E006-A2917F38D7A4";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube11_scaleZ";
	rename -uid "74E61E82-4483-4DBC-583E-7AA80C23C87B";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube12_visibility";
	rename -uid "7769F1AE-454C-EBFB-AB02-2AA2F1EDDC32";
	setAttr ".tan" 5;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 1 24 1 48 1;
	setAttr -s 3 ".kit[0:2]"  9 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
createNode animCurveTA -n "pCube12_rotateX";
	rename -uid "E1D3CFD1-4764-0E36-EBA9-9C905001DF37";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTA -n "pCube12_rotateY";
	rename -uid "368A727B-4A2D-D532-2057-D5B900B71001";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTA -n "pCube12_rotateZ";
	rename -uid "B3BC521D-4DC1-7FA3-E03F-1F9215F96E6C";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube12_scaleX";
	rename -uid "90AE5DA5-40AD-8499-859D-89A34D42CC15";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube12_scaleY";
	rename -uid "897F02AB-46AE-F6DB-C803-BC89A9E08A06";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube12_scaleZ";
	rename -uid "0B9259B4-49CA-C4B5-38FE-4084556E24D6";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube13_visibility";
	rename -uid "78836567-44B1-644F-FEEA-5A88D7892F96";
	setAttr ".tan" 5;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 1 24 1 48 1;
	setAttr -s 3 ".kit[0:2]"  9 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
createNode animCurveTA -n "pCube13_rotateX";
	rename -uid "3B79AF3E-4402-D640-4336-0F92D29E3C29";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTA -n "pCube13_rotateY";
	rename -uid "4E4C7D3F-4EEB-F162-B63E-ABA47197498E";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTA -n "pCube13_rotateZ";
	rename -uid "DDA40959-48FB-26EF-D2DE-DAB2B18AF774";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube13_scaleX";
	rename -uid "3E8D82A7-4CEA-EEE5-4091-C58A93311E93";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube13_scaleY";
	rename -uid "7EE14EA3-4305-9BFB-4B61-5F81D6370420";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube13_scaleZ";
	rename -uid "F0B6C63F-4F0D-4A8C-3AE0-FEB73E8CE264";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube14_visibility";
	rename -uid "4AD942FC-444B-3349-EE7E-B9ACD3299F70";
	setAttr ".tan" 5;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 1 24 1 48 1;
	setAttr -s 3 ".kit[0:2]"  9 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
createNode animCurveTA -n "pCube14_rotateX";
	rename -uid "112D1D97-433E-9BD8-4734-FBB4CB5E2EC4";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTA -n "pCube14_rotateY";
	rename -uid "35912A51-46E0-31F6-975C-71979A0FA7B2";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTA -n "pCube14_rotateZ";
	rename -uid "33092F37-4D95-E8BD-CEB3-B49AA9DE18F1";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube14_scaleX";
	rename -uid "BE81D86D-4107-0F4A-1E6C-839E0605181D";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube14_scaleY";
	rename -uid "07D7465D-439E-D289-AE50-448041E63067";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "pCube14_scaleZ";
	rename -uid "307387E7-4106-8CDC-9AB6-7A981D18D73D";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0.10607598334292205 24 0.10607598334292205
		 48 0.10607598334292205;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "polySurface1_visibility";
	rename -uid "6C81963B-42E8-FC2A-FB25-A286C5E2521D";
	setAttr ".tan" 5;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 1 24 1 48 1;
	setAttr -s 3 ".kit[0:2]"  9 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
createNode animCurveTA -n "polySurface1_rotateX";
	rename -uid "315D15E1-44E9-DAD6-EFA1-318A08598A33";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTA -n "polySurface1_rotateY";
	rename -uid "65F92604-43EC-23D1-3F12-6BA615341C24";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTA -n "polySurface1_rotateZ";
	rename -uid "7086709A-4A2F-4259-F481-C8AA518F2720";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 0 24 0 48 0;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "polySurface1_scaleX";
	rename -uid "7F8609F2-4959-7B8D-E8A4-C6A513F9A29C";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 1 24 1 48 1;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "polySurface1_scaleY";
	rename -uid "3AE467E6-4917-1D94-724F-F6BDDB27BDFD";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 1 24 1 48 1;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode animCurveTU -n "polySurface1_scaleZ";
	rename -uid "1BD9803A-40AE-9204-36D8-FAAD7FE82A13";
	setAttr ".tan" 1;
	setAttr ".wgt" no;
	setAttr -s 3 ".ktv[0:2]"  1 1 24 1 48 1;
	setAttr -s 3 ".kit[0:2]"  18 1 1;
	setAttr -s 3 ".kot[0:2]"  18 1 1;
	setAttr -s 3 ".kix[1:2]"  1 1;
	setAttr -s 3 ".kiy[1:2]"  0 0;
	setAttr -s 3 ".kox[1:2]"  1 1;
	setAttr -s 3 ".koy[1:2]"  0 0;
createNode phongE -n "phongE5";
	rename -uid "5773DDA1-4248-7217-B788-E6A25C90165E";
	setAttr ".c" -type "float3" 0 0.713 0 ;
	setAttr ".it" -type "float3" 0.11966125 0.11966125 0.11966125 ;
	setAttr ".gi" 1;
createNode animCurveTU -n "phongE2_glowIntensity";
	rename -uid "61C4F3A6-42B0-B633-6492-6FAD66E550C3";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 4 ".ktv[0:3]"  1 0.35897436738014221 8 0.72649574279785156
		 14 0.72649574279785156 21 0.38461539149284363;
createNode shapeEditorManager -n "shapeEditorManager";
	rename -uid "4ADE8BA4-4EB2-7FA6-51A7-8A8D6A5F21E6";
createNode poseInterpolatorManager -n "poseInterpolatorManager";
	rename -uid "674B4EBF-4869-4855-BB51-8E9DDEB4AFD1";
select -ne :time1;
	setAttr ".o" 45;
	setAttr ".unw" 45;
select -ne :hardwareRenderingGlobals;
	setAttr ".etmr" no;
	setAttr ".tmr" 4096;
select -ne :renderPartition;
	setAttr -s 6 ".st";
select -ne :renderGlobalsList1;
select -ne :defaultShaderList1;
	setAttr -s 8 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderingList1;
select -ne :initialShadingGroup;
	setAttr -s 4 ".dsm";
	setAttr ".ro" yes;
	setAttr -s 4 ".gn";
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultRenderGlobals;
	setAttr ".ep" 1;
select -ne :defaultResolution;
	setAttr ".w" 640;
	setAttr ".h" 480;
	setAttr ".dar" 1.3333332538604736;
select -ne :defaultColorMgtGlobals;
	setAttr ".cme" no;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
select -ne :ikSystem;
	setAttr -s 4 ".sol";
connectAttr "groupId1.id" "pTorusShape1.iog.og[0].gid";
connectAttr ":initialShadingGroup.mwc" "pTorusShape1.iog.og[0].gco";
connectAttr "groupParts1.og" "pTorusShape1.i";
connectAttr "groupId2.id" "pTorusShape1.ciog.cog[0].cgid";
connectAttr "groupId3.id" "pCubeShape1.iog.og[0].gid";
connectAttr ":initialShadingGroup.mwc" "pCubeShape1.iog.og[0].gco";
connectAttr "groupParts2.og" "pCubeShape1.i";
connectAttr "groupId4.id" "pCubeShape1.ciog.cog[0].cgid";
connectAttr "polySurface1_translateX.o" "polySurface1.tx";
connectAttr "polySurface1_translateY.o" "polySurface1.ty";
connectAttr "polySurface1_translateZ.o" "polySurface1.tz";
connectAttr "polySurface1_visibility.o" "polySurface1.v";
connectAttr "polySurface1_rotateX.o" "polySurface1.rx";
connectAttr "polySurface1_rotateY.o" "polySurface1.ry";
connectAttr "polySurface1_rotateZ.o" "polySurface1.rz";
connectAttr "polySurface1_scaleX.o" "polySurface1.sx";
connectAttr "polySurface1_scaleY.o" "polySurface1.sy";
connectAttr "polySurface1_scaleZ.o" "polySurface1.sz";
connectAttr "polyUnite1.out" "polySurfaceShape1.i";
connectAttr "pCube2_translateX.o" "pCube2.tx";
connectAttr "pCube2_translateY.o" "pCube2.ty";
connectAttr "pCube2_translateZ.o" "pCube2.tz";
connectAttr "pCube2_visibility.o" "pCube2.v";
connectAttr "pCube2_rotateX.o" "pCube2.rx";
connectAttr "pCube2_rotateY.o" "pCube2.ry";
connectAttr "pCube2_rotateZ.o" "pCube2.rz";
connectAttr "pCube2_scaleX.o" "pCube2.sx";
connectAttr "pCube2_scaleY.o" "pCube2.sy";
connectAttr "pCube2_scaleZ.o" "pCube2.sz";
connectAttr "polySmoothFace1.out" "pCubeShape2.i";
connectAttr "pCube3_translateX.o" "pCube3.tx";
connectAttr "pCube3_translateY.o" "pCube3.ty";
connectAttr "pCube3_translateZ.o" "pCube3.tz";
connectAttr "pCube3_visibility.o" "pCube3.v";
connectAttr "pCube3_rotateX.o" "pCube3.rx";
connectAttr "pCube3_rotateY.o" "pCube3.ry";
connectAttr "pCube3_rotateZ.o" "pCube3.rz";
connectAttr "pCube3_scaleX.o" "pCube3.sx";
connectAttr "pCube3_scaleY.o" "pCube3.sy";
connectAttr "pCube3_scaleZ.o" "pCube3.sz";
connectAttr "polySmoothFace2.out" "pCubeShape3.i";
connectAttr "pCube4_translateX.o" "pCube4.tx";
connectAttr "pCube4_translateY.o" "pCube4.ty";
connectAttr "pCube4_translateZ.o" "pCube4.tz";
connectAttr "pCube4_visibility.o" "pCube4.v";
connectAttr "pCube4_rotateX.o" "pCube4.rx";
connectAttr "pCube4_rotateY.o" "pCube4.ry";
connectAttr "pCube4_rotateZ.o" "pCube4.rz";
connectAttr "pCube4_scaleX.o" "pCube4.sx";
connectAttr "pCube4_scaleY.o" "pCube4.sy";
connectAttr "pCube4_scaleZ.o" "pCube4.sz";
connectAttr "polySmoothFace3.out" "pCubeShape4.i";
connectAttr "pCube5_translateX.o" "pCube5.tx";
connectAttr "pCube5_translateY.o" "pCube5.ty";
connectAttr "pCube5_translateZ.o" "pCube5.tz";
connectAttr "pCube5_visibility.o" "pCube5.v";
connectAttr "pCube5_rotateX.o" "pCube5.rx";
connectAttr "pCube5_rotateY.o" "pCube5.ry";
connectAttr "pCube5_rotateZ.o" "pCube5.rz";
connectAttr "pCube5_scaleX.o" "pCube5.sx";
connectAttr "pCube5_scaleY.o" "pCube5.sy";
connectAttr "pCube5_scaleZ.o" "pCube5.sz";
connectAttr "polySmoothFace4.out" "pCubeShape5.i";
connectAttr "pCube6_translateX.o" "pCube6.tx";
connectAttr "pCube6_translateY.o" "pCube6.ty";
connectAttr "pCube6_translateZ.o" "pCube6.tz";
connectAttr "pCube6_visibility.o" "pCube6.v";
connectAttr "pCube6_rotateX.o" "pCube6.rx";
connectAttr "pCube6_rotateY.o" "pCube6.ry";
connectAttr "pCube6_rotateZ.o" "pCube6.rz";
connectAttr "pCube6_scaleX.o" "pCube6.sx";
connectAttr "pCube6_scaleY.o" "pCube6.sy";
connectAttr "pCube6_scaleZ.o" "pCube6.sz";
connectAttr "polySmoothFace5.out" "pCubeShape6.i";
connectAttr "pCube7_translateX.o" "pCube7.tx";
connectAttr "pCube7_translateY.o" "pCube7.ty";
connectAttr "pCube7_translateZ.o" "pCube7.tz";
connectAttr "pCube7_visibility.o" "pCube7.v";
connectAttr "pCube7_rotateX.o" "pCube7.rx";
connectAttr "pCube7_rotateY.o" "pCube7.ry";
connectAttr "pCube7_rotateZ.o" "pCube7.rz";
connectAttr "pCube7_scaleX.o" "pCube7.sx";
connectAttr "pCube7_scaleY.o" "pCube7.sy";
connectAttr "pCube7_scaleZ.o" "pCube7.sz";
connectAttr "polySmoothFace6.out" "pCubeShape7.i";
connectAttr "pCube8_translateX.o" "pCube8.tx";
connectAttr "pCube8_translateY.o" "pCube8.ty";
connectAttr "pCube8_translateZ.o" "pCube8.tz";
connectAttr "pCube8_visibility.o" "pCube8.v";
connectAttr "pCube8_rotateX.o" "pCube8.rx";
connectAttr "pCube8_rotateY.o" "pCube8.ry";
connectAttr "pCube8_rotateZ.o" "pCube8.rz";
connectAttr "pCube8_scaleX.o" "pCube8.sx";
connectAttr "pCube8_scaleY.o" "pCube8.sy";
connectAttr "pCube8_scaleZ.o" "pCube8.sz";
connectAttr "polySmoothFace7.out" "pCubeShape8.i";
connectAttr "pCube9_translateX.o" "pCube9.tx";
connectAttr "pCube9_translateY.o" "pCube9.ty";
connectAttr "pCube9_translateZ.o" "pCube9.tz";
connectAttr "pCube9_visibility.o" "pCube9.v";
connectAttr "pCube9_rotateX.o" "pCube9.rx";
connectAttr "pCube9_rotateY.o" "pCube9.ry";
connectAttr "pCube9_rotateZ.o" "pCube9.rz";
connectAttr "pCube9_scaleX.o" "pCube9.sx";
connectAttr "pCube9_scaleY.o" "pCube9.sy";
connectAttr "pCube9_scaleZ.o" "pCube9.sz";
connectAttr "polySmoothFace8.out" "pCubeShape9.i";
connectAttr "pCube10_translateX.o" "pCube10.tx";
connectAttr "pCube10_translateY.o" "pCube10.ty";
connectAttr "pCube10_translateZ.o" "pCube10.tz";
connectAttr "pCube10_visibility.o" "pCube10.v";
connectAttr "pCube10_rotateX.o" "pCube10.rx";
connectAttr "pCube10_rotateY.o" "pCube10.ry";
connectAttr "pCube10_rotateZ.o" "pCube10.rz";
connectAttr "pCube10_scaleX.o" "pCube10.sx";
connectAttr "pCube10_scaleY.o" "pCube10.sy";
connectAttr "pCube10_scaleZ.o" "pCube10.sz";
connectAttr "polySmoothFace9.out" "pCubeShape10.i";
connectAttr "pCube11_translateX.o" "pCube11.tx";
connectAttr "pCube11_translateY.o" "pCube11.ty";
connectAttr "pCube11_translateZ.o" "pCube11.tz";
connectAttr "pCube11_visibility.o" "pCube11.v";
connectAttr "pCube11_rotateX.o" "pCube11.rx";
connectAttr "pCube11_rotateY.o" "pCube11.ry";
connectAttr "pCube11_rotateZ.o" "pCube11.rz";
connectAttr "pCube11_scaleX.o" "pCube11.sx";
connectAttr "pCube11_scaleY.o" "pCube11.sy";
connectAttr "pCube11_scaleZ.o" "pCube11.sz";
connectAttr "polySmoothFace10.out" "pCubeShape11.i";
connectAttr "pCube12_translateX.o" "pCube12.tx";
connectAttr "pCube12_translateY.o" "pCube12.ty";
connectAttr "pCube12_translateZ.o" "pCube12.tz";
connectAttr "pCube12_visibility.o" "pCube12.v";
connectAttr "pCube12_rotateX.o" "pCube12.rx";
connectAttr "pCube12_rotateY.o" "pCube12.ry";
connectAttr "pCube12_rotateZ.o" "pCube12.rz";
connectAttr "pCube12_scaleX.o" "pCube12.sx";
connectAttr "pCube12_scaleY.o" "pCube12.sy";
connectAttr "pCube12_scaleZ.o" "pCube12.sz";
connectAttr "polySmoothFace11.out" "pCubeShape12.i";
connectAttr "pCube13_translateX.o" "pCube13.tx";
connectAttr "pCube13_translateY.o" "pCube13.ty";
connectAttr "pCube13_translateZ.o" "pCube13.tz";
connectAttr "pCube13_visibility.o" "pCube13.v";
connectAttr "pCube13_rotateX.o" "pCube13.rx";
connectAttr "pCube13_rotateY.o" "pCube13.ry";
connectAttr "pCube13_rotateZ.o" "pCube13.rz";
connectAttr "pCube13_scaleX.o" "pCube13.sx";
connectAttr "pCube13_scaleY.o" "pCube13.sy";
connectAttr "pCube13_scaleZ.o" "pCube13.sz";
connectAttr "polySmoothFace12.out" "pCubeShape13.i";
connectAttr "pCube14_translateX.o" "pCube14.tx";
connectAttr "pCube14_translateY.o" "pCube14.ty";
connectAttr "pCube14_translateZ.o" "pCube14.tz";
connectAttr "pCube14_visibility.o" "pCube14.v";
connectAttr "pCube14_rotateX.o" "pCube14.rx";
connectAttr "pCube14_rotateY.o" "pCube14.ry";
connectAttr "pCube14_rotateZ.o" "pCube14.rz";
connectAttr "pCube14_scaleX.o" "pCube14.sx";
connectAttr "pCube14_scaleY.o" "pCube14.sy";
connectAttr "pCube14_scaleZ.o" "pCube14.sz";
connectAttr "polySmoothFace13.out" "pCubeShape14.i";
relationship "link" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "phongE1SG.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "phongE2SG.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "phongE3SG.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "phongE4SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "phongE1SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "phongE2SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "phongE3SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "phongE4SG.message" ":defaultLightSet.message";
connectAttr "layerManager.dli[0]" "defaultLayer.id";
connectAttr "renderLayerManager.rlmi[0]" "defaultRenderLayer.rlid";
connectAttr "polyCube1.out" "polyExtrudeFace1.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace1.mp";
connectAttr "pTorusShape1.o" "polyUnite1.ip[0]";
connectAttr "pCubeShape1.o" "polyUnite1.ip[1]";
connectAttr "pTorusShape1.wm" "polyUnite1.im[0]";
connectAttr "pCubeShape1.wm" "polyUnite1.im[1]";
connectAttr "polyTorus1.out" "groupParts1.ig";
connectAttr "groupId1.id" "groupParts1.gi";
connectAttr "polyExtrudeFace1.out" "groupParts2.ig";
connectAttr "groupId3.id" "groupParts2.gi";
connectAttr "phongE5.oc" "phongE1SG.ss";
connectAttr "polySurfaceShape1.iog" "phongE1SG.dsm" -na;
connectAttr "phongE1SG.msg" "materialInfo1.sg";
connectAttr "phongE5.msg" "materialInfo1.m";
connectAttr "polyCube2.out" "polyPoke1.ip";
connectAttr "pCubeShape2.wm" "polyPoke1.mp";
connectAttr "polyPoke1.out" "polySmoothFace1.ip";
connectAttr "polySurfaceShape2.o" "polySmoothFace2.ip";
connectAttr "polySurfaceShape3.o" "polySmoothFace3.ip";
connectAttr "polySurfaceShape4.o" "polySmoothFace4.ip";
connectAttr "polySurfaceShape5.o" "polySmoothFace5.ip";
connectAttr "polySurfaceShape6.o" "polySmoothFace6.ip";
connectAttr "polySurfaceShape7.o" "polySmoothFace7.ip";
connectAttr "polySurfaceShape8.o" "polySmoothFace8.ip";
connectAttr "polySurfaceShape9.o" "polySmoothFace9.ip";
connectAttr "polySurfaceShape10.o" "polySmoothFace10.ip";
connectAttr "polySurfaceShape11.o" "polySmoothFace11.ip";
connectAttr "polySurfaceShape12.o" "polySmoothFace12.ip";
connectAttr "polySurfaceShape13.o" "polySmoothFace13.ip";
connectAttr "phongE2.oc" "phongE2SG.ss";
connectAttr "pCubeShape14.iog" "phongE2SG.dsm" -na;
connectAttr "pCubeShape13.iog" "phongE2SG.dsm" -na;
connectAttr "pCubeShape12.iog" "phongE2SG.dsm" -na;
connectAttr "pCubeShape8.iog" "phongE2SG.dsm" -na;
connectAttr "pCubeShape5.iog" "phongE2SG.dsm" -na;
connectAttr "phongE2SG.msg" "materialInfo2.sg";
connectAttr "phongE2.msg" "materialInfo2.m";
connectAttr "phongE3.oc" "phongE3SG.ss";
connectAttr "pCubeShape3.iog" "phongE3SG.dsm" -na;
connectAttr "pCubeShape4.iog" "phongE3SG.dsm" -na;
connectAttr "pCubeShape11.iog" "phongE3SG.dsm" -na;
connectAttr "pCubeShape6.iog" "phongE3SG.dsm" -na;
connectAttr "pCubeShape2.iog" "phongE3SG.dsm" -na;
connectAttr "phongE3SG.msg" "materialInfo3.sg";
connectAttr "phongE3.msg" "materialInfo3.m";
connectAttr "phongE4.oc" "phongE4SG.ss";
connectAttr "pCubeShape9.iog" "phongE4SG.dsm" -na;
connectAttr "pCubeShape10.iog" "phongE4SG.dsm" -na;
connectAttr "pCubeShape7.iog" "phongE4SG.dsm" -na;
connectAttr "phongE4SG.msg" "materialInfo4.sg";
connectAttr "phongE4.msg" "materialInfo4.m";
connectAttr "phongE1SG.pa" ":renderPartition.st" -na;
connectAttr "phongE2SG.pa" ":renderPartition.st" -na;
connectAttr "phongE3SG.pa" ":renderPartition.st" -na;
connectAttr "phongE4SG.pa" ":renderPartition.st" -na;
connectAttr "phongE5.msg" ":defaultShaderList1.s" -na;
connectAttr "phongE2.msg" ":defaultShaderList1.s" -na;
connectAttr "phongE3.msg" ":defaultShaderList1.s" -na;
connectAttr "phongE4.msg" ":defaultShaderList1.s" -na;
connectAttr "defaultRenderLayer.msg" ":defaultRenderingList1.r" -na;
connectAttr "pTorusShape1.iog.og[0]" ":initialShadingGroup.dsm" -na;
connectAttr "pTorusShape1.ciog.cog[0]" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape1.iog.og[0]" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape1.ciog.cog[0]" ":initialShadingGroup.dsm" -na;
connectAttr "groupId1.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId2.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId3.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId4.msg" ":initialShadingGroup.gn" -na;
// End of HealthCross.ma
